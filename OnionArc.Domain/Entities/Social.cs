using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Social : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}