using Microsoft.EntityFrameworkCore;

namespace CtrlLove.Models;

public class CtrlLoveContext : DbContext
{
    public CtrlLoveContext(DbContextOptions<CtrlLoveContext> contextOptions) : base(contextOptions)
    {
        
    }

    public DbSet<ChatRoomModel> ChatRoomModels { get; set; }
    public DbSet<MessageModel> MessageModels { get; set; }
    public DbSet<UserModel> UserModel { get; set; }
    public DbSet<PhotoModel> Photos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatRoomModel>()
            .HasMany(cr => cr.Participants)
            .WithMany();

    }
}