using CtrlLove.DAL;
using CtrlLove.Models;
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
    
    [HttpGet("/users/{userId}/chatrooms")]
    public IActionResult ShowChatroomsByUser(Guid userId)
    {
        return Ok(_chatService.GetChatroomsByUserID(userId));
    }

    [HttpGet("/users/{userId}")]
    public IActionResult ShowUserById(Guid userId)
    {
        return Ok(_userService.GetUserById(userId));
    }
    
    [HttpGet("/matches/{userId}")]
    public IActionResult ShowMatchesByUser(Guid userId)
    {
        return Ok(_userService.GetMatchesByUser(userId));
    }
    
    [HttpGet("/chatrooms/{chatroomId}/messages")]
    public IActionResult ShowMessagesByChatroomId(Guid chatroomId)
    {
        return Ok(_chatService.GetMessagesByChatroomId(chatroomId));
    }
    
}