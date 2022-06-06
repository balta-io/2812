namespace Blog.Models;

public class Tag
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; }= string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}