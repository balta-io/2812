namespace Blog.ViewModels.Posts;

public class ListPostsViewModel
{
    public int Id { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    public string Category { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}