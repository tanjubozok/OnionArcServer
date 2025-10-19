using Microsoft.EntityFrameworkCore;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Social> Socials { get; set; }
}