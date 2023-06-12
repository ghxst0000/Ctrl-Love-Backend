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
    public async Task<List<UserModel>> ShowAllUsers()
    {
        return await _userService.GetAllUsers();
    }
    
    [HttpGet("/users/{userId}/chatrooms/{chatroomId}/messages")]
    public async Task<List<MessageModel>> ShowMessagesByChatroomId(Guid userId, Guid chatroomId)
    {
        await _userService.GetUserById(userId);
        return await _chatService.GetMessagesByChatroomId(chatroomId, userId);
    }
    
    [HttpGet("/users/{userId}/chatrooms")]
    public async Task<List<ChatRoomModel>> ShowChatroomsByUser(Guid userId)
    {
        await _userService.GetUserById(userId);
        return await _chatService.GetChatroomsByUserId(userId);
    }
    
    [HttpGet("/users/{userId}/matches")]
    public async Task<List<UserModel>> ShowMatchesByUser(Guid userId)
    {
        return await _userService.GetMatchesByUser(userId);
    }

    [HttpGet("/users/{userId}")]
    public async Task<UserModel> ShowUserById(Guid userId)
    {
        return await _userService.GetUserById(userId);
        
    }
    
    [HttpDelete("/users/{userId}")]
    public async Task<bool> DeleteUserById(Guid userId)
    {
        return await _userService.DeleteUserById(userId);
        
    }
    
    [HttpPost("/users/")]
    public async Task<UserModel> PostNewUser([FromBody] UserModel user)
    {
        return await _userService.AddNewUser(user);
        
    }
}