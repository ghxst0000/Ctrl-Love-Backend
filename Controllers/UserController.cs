using System.ComponentModel.DataAnnotations;
using CtrlLove.Models;
using CtrlLove.Models.DTOs;
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
    private readonly CtrlLoveService _ctrlLoveService;

    public UserController(IUserService userService, IChatService chatService, CtrlLoveService ctrlLoveService)
    {
        _userService = userService;
        _chatService = chatService;
        _ctrlLoveService = ctrlLoveService;
    }
    
    

    [HttpGet]
    public async Task<List<PublicUserDTO>> ShowAllUsers()
    {
        var users = await _userService.GetAllUsers();
        var publicUsers = users.Select(user => (PublicUserDTO)user).ToList();
        return publicUsers;
    }
    
    [HttpGet("/{userId}/chatrooms/{chatroomId}/messages")]
    public async Task<List<MessageModel>> ShowMessagesByChatroomId(Guid userId, Guid chatroomId)
    {
        return await _chatService.GetMessagesByChatroomId(chatroomId, userId);
    }
    
    [HttpGet("/{userId}/chatrooms")]
    public async Task<List<ChatRoomModel>> ShowChatroomsByUser(Guid userId)
    {
        return await _chatService.GetChatroomsByUserId(userId);
    }
    
    [HttpGet("/{userId}/matches")]
    public async Task<List<PublicUserDTO>> ShowMatchesByUser(Guid userId)
    {
        return (await _userService.GetMatchesByUser(userId)).Cast<PublicUserDTO>().ToList();;
    }

    [HttpGet("/{userId}")]
    public async Task<PublicUserDTO> ShowUserById(Guid userId)
    {
        return (await _ctrlLoveService.FindEntityById<UserModel>(userId));

    }
    
    [HttpPost("/sign-in")]
    public async Task<bool> SignInUser([FromBody] LoginCredentialsDTO details)
    {
        Console.WriteLine(details);
        return await _userService.SignInUser(details.Email, details.Password);
    }

    [HttpGet("/my-profile/{userId}")]
    public async Task<PrivateUserDTO> ShowOwnUserById(Guid userId)
    {
        return (await _ctrlLoveService.FindEntityById<UserModel>(userId));

    }
    
    [HttpDelete("/{userId}")]
    public async Task<bool> DeleteUserById(Guid userId)
    {
        return await _userService.DeleteUserById(userId);
        
    }
    
    [HttpPost]
    public async Task<PrivateUserDTO> PostNewUser([FromBody] UserModel user)
    {
        Console.WriteLine(user.ToString());
        return await _userService.AddNewUser(user);
        
    }
}