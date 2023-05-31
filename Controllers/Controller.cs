using CtrlLove.DAL;
using CtrlLove.Service;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/")]

public class Controller
{
    //repositoryk
    private static readonly IUserService _userService;
    private static readonly IChatService _chatService;

    [HttpGet("/users")]
    public IActionResult GetUsers(int maxAge = 0, int minAge = 0, string location = null, Gender gender = null,
        Gender desiredGender = null, Interest interest = null);
    {
        return _userService.GetAllUsers();
    }

    [HttpGet("/users/{userId}")]
    public IActionResult ShowUserById(string userId)
    {
        return _userService.GetUserById(userId);
    }
    
    [HttpGet("/users/{userId}")]
    public IActionResult ggg(string userId)
    {
        return _userService.GetUserById(userId);
    }
    
    [HttpGet("/chatrooms/{chatroomId}/messages")]
    public IActionResult ShowMessagesByChatroomId(string chatroomId)
    {
        return _chatService.GetMessagesByChatroomId(chatroomId);
    }

    [HttpGet("/chatrooms/byuser/{userId}")]
    public IActionResult ShowChatroomsByUser(string userId)
    {
        return _chatService.GetChatroomsByUserID(userId);
    }
}