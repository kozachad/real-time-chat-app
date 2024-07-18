using ChatAppServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAppServer.WebApi.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name);
            entity.Property(e => e.Password);
            entity.Property(e => e.Salt);
            entity.Property(e => e.Avatar);
            entity.Property(e => e.Status);
            entity.Property(e=> e.Role);
            entity.Property(e=> e.refreshToken);
            entity.Property(e => e.ExpiryDate);
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.ToTable("chat");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Message);
            entity.Property(e => e.Date);
            entity.Property(e => e.Image);
            entity.Property(e => e.UserId);
            entity.Property(e=> e.isRead);
            entity.Property(e=> e.toUserId);

            //entity.Property(e => e.isDeleted);
        });
    }

    
}

