namespace Blog.Models;

public class User
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();
}