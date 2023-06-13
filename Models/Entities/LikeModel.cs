using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CtrlLove.Models;

public class LikeModel
{

    [Key]
    [Column(Order = 1)]
    public Guid LikedByUserId { get; set; }
    
    [Key]
    [Column(Order = 2)]
    public Guid LikedUserId { get; set; }
    public bool Liked { get; set; }
    [ForeignKey(nameof(LikedByUserId))]
    public UserModel LikedByUser { get; set; }

    [ForeignKey(nameof(LikedUserId))]
    public UserModel LikedUser { get; set; }
}