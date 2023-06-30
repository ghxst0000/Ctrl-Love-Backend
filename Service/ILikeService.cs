using CtrlLove.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface ILikeService
{
    Task<bool> LikeUser(Guid currentUser, Guid likedUser, bool isLiked);
}