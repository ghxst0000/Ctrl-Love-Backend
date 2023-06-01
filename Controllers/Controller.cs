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
    private readonly IUserService _userService;
    private readonly IChatService _chatService;

    public Controller(IUserService userService)
    {
        _userService = userService;
    }

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