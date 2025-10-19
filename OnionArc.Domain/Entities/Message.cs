using OnionArc.Domain.Entities.Common;

namespace OnionArc.Domain.Entities;

public class Message : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public bool IsRead { get; set; } = false;
}