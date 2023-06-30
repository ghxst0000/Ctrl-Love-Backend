using CtrlLove.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CtrlLove.Controllers;
[ApiController]
[Route("/api/v1/likes/")]
public class LikeController : ControllerBase
{
    public ILikeService _LikeService { get; set; }

    public LikeController(ILikeService likeService)
    {
        _LikeService = likeService;
    }

    [HttpPost("like")]
    public async Task<bool> LikeUser([FromBody] Guid likedUser)
    {
        var currentUser  = Request.Cookies["id"];
        var guid = Guid.Parse(currentUser);
        return await _LikeService.LikeUser(guid, likedUser, true);
    }
    
    [HttpPost("dislike")]
    public async Task<bool> DislikeUser([FromBody] Guid dislikedUser)
    {
        var currentUser  = Request.Cookies["id"];
        var guid = Guid.Parse(currentUser);
        return await _LikeService.LikeUser(guid, dislikedUser, false);
    }
}