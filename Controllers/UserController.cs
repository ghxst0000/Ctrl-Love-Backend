using CtrlLove.Models;
using CtrlLove.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/api/v1/users")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IChatService _chatService;

    public UserController(IUserService userService, IChatService chatService)
    {
        _userService = userService;
        _chatService = chatService;
    }
    
    

    [HttpGet]
    public async Task<List<UserModel>> ShowAllUsers()
    {
        return await _userService.GetAllUsers();
    }
    
    [HttpGet("/{userId}/chatrooms/{chatroomId}/messages")]
    public async Task<List<MessageModel>> ShowMessagesByChatroomId(Guid userId, Guid chatroomId)
    {
        await _userService.GetUserById(userId);
        return await _chatService.GetMessagesByChatroomId(chatroomId, userId);
    }
    
    [HttpGet("/{userId}/chatrooms")]
    public async Task<List<ChatRoomModel>> ShowChatroomsByUser(Guid userId)
    {
        await _userService.GetUserById(userId);
        return await _chatService.GetChatroomsByUserId(userId);
    }
    
    [HttpGet("/{userId}/matches")]
    public async Task<List<UserModel>> ShowMatchesByUser(Guid userId)
    {
        return await _userService.GetMatchesByUser(userId);
    }

    [HttpGet("/{userId}")]
    public async Task<UserModel> ShowUserById(Guid userId)
    {
        return await _userService.GetUserById(userId);
        
    }
    
    [HttpDelete("/{userId}")]
    public async Task<bool> DeleteUserById(Guid userId)
    {
        return await _userService.DeleteUserById(userId);
        
    }
    
    [HttpPost]
    public async Task<UserModel> PostNewUser([FromBody] UserModel user)
    {
        return await _userService.AddNewUser(user);
        
    }
}