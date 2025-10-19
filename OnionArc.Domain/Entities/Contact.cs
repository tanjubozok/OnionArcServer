using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Contact : BaseEntity
{
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string MapUrl { get; set; } = null!;
}