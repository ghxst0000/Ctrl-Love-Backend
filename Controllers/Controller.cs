using CtrlLove.DAL;
using CtrlLove.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/")]

public class Controller : ControllerBase
{
    //repositoryk
    private static readonly IUserService _userService;
    private static readonly IChatService _chatService;

    [HttpGet("/users")]
    public IActionResult ShowAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("/users/{userId}")]
    public IActionResult ShowUserById(string userId)
    {
        return Ok(_userService.GetUserById(userId));
    }
    
    [HttpGet("/matches/{userId}")]
    public IActionResult ShowMatchesByUser(string userId)
    {
        return Ok(_userService.GetMatchesByUser(userId));
    }
    
    [HttpGet("/chatrooms/{chatroomId}/messages")]
    public IActionResult ShowMessagesByChatroomId(string chatroomId)
    {
        return Ok(_chatService.GetMessagesByChatroomId(chatroomId));
    }

    [HttpGet("/chatrooms/byuser/{userId}")]
    public IActionResult ShowChatroomsByUser(string userId)
    {
        return Ok(_chatService.GetChatroomsByUserID(userId));
    }
}