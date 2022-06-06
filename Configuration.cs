namespace Blog;

public static class Configuration
{
    public static string JwtKey = "";
    public static string ApiKeyName = "";
    public static string ApiKey = "";
    public static SmtpConfiguration Smtp = new();

    public class SmtpConfiguration
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 25;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}