using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; } = null!;
    public string CoverImage { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}