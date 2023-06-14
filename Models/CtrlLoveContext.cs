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
    public DbSet<InterestModel> Interests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatRoomModel>()
            .HasMany(cr => cr.Participants)
            .WithMany();

        modelBuilder.Entity<LikeModel>()
            .HasKey(ul => new { ul.LikedByUserId, ul.LikedUserId });

        modelBuilder.Entity<LikeModel>()
            .HasOne(ul => ul.LikedByUser)
            .WithMany(u => u.Likes)
            .HasForeignKey(ul => ul.LikedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LikeModel>()
            .HasOne(ul => ul.LikedUser)
            .WithMany()
            .HasForeignKey(ul => ul.LikedUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Interests)
            .WithMany();

    }
}