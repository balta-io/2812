namespace Blog.Models;

public class Role
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();
}