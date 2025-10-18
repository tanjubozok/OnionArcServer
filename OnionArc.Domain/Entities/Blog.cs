using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}