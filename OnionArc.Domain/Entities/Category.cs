using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public List<Blog> Blogs { get; set; }
}