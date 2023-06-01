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

    public Controller(IUserService userService, IChatService chatService)
    {
        _userService = userService;
        _chatService = chatService;
    }
    
    

    [HttpGet("/users")]
    public IActionResult ShowAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
    
    [HttpGet("/users/{userId}/chatrooms/{chatroomId}/messages")]
    public IActionResult ShowMessagesByChatroomId(Guid userId, Guid chatroomId)
    {
        _userService.GetUserById(userId);
        return Ok(_chatService.GetMessagesByChatroomId(chatroomId, userId));
    }
    
    [HttpGet("/users/{userId}/chatrooms")]
    public IActionResult ShowChatroomsByUser(Guid userId)
    {
        _userService.GetUserById(userId);
        return Ok(_chatService.GetChatroomsByUserId(userId));
    }
    
    [HttpGet("/users/{userId}/matches")]
    public IActionResult ShowMatchesByUser(Guid userId)
    {
        return Ok(_userService.GetMatchesByUser(userId));
    }

    [HttpGet("/users/{userId}")]
    public IActionResult ShowUserById(Guid userId)
    {
        return Ok(_userService.GetUserById(userId));
        
    }
    
    [HttpDelete("/users/{userId}")]
    public IActionResult DeleteUserById(Guid userId)
    {
        return Ok(_userService.DeleteUserById(userId));
        
    }
    
    [HttpPost("/users/")]
    public IActionResult PostNewUser([FromBody] UserModel user)
    {
        return Ok(_userService.AddNewUser(user));
        
    }
}