using CtrlLove.Models;
using CtrlLove.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CtrlLove.Service;

public class LikeService : ILikeService
{
    private CtrlLoveContext _context { get; set; }

    public LikeService(CtrlLoveContext context)
    {
        _context = context;
    }
    
    public async Task<bool> LikeUser(Guid currentUser, Guid likedUser, bool isLiked)
    {
       var user = _context.UserModel.FirstOrDefault(u => u.Id.Equals(currentUser));
       var likedFoundUser = _context.UserModel.FirstOrDefault(u => u.Id.Equals(likedUser));
       var like = new LikeModel { LikedUser = likedFoundUser, LikedUserId = currentUser, Liked = isLiked };
       user.Likes.Add(like);
       await _context.SaveChangesAsync();
       return true;
    }
    
}