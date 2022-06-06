using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}