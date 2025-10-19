using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public List<Blog>? Blogs { get; set; }
}