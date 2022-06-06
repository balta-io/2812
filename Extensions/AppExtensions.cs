using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Extensions;

public static class AppExtensions
{
    public static void LoadConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey");
        Configuration.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName");
        Configuration.ApiKey = builder.Configuration.GetValue<string>("ApiKey");

        var smtp = new Configuration.SmtpConfiguration();
        builder.Configuration.GetSection("SmtpConfiguration").Bind(smtp);
        Configuration.Smtp = smtp;
    }

    public static void ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    public static void ConfigureMvc(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        
        builder.Services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
        });

        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
        
        builder
            .Services
            .AddControllers()
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
    }

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<BlogDataContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddTransient<TokenService>();
        builder.Services.AddTransient<EmailService>();
    }
}