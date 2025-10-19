using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Social : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Icon { get; set; } = null!;
}