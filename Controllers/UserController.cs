using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using CtrlLove.Models;
using CtrlLove.Models.DTOs;
using CtrlLove.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/api/v1/users/")]
[Authorize]

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
        var currentUser  = Request.Cookies["id"];
        var guid = Guid.Parse(currentUser);
        var users = await _userService.GetAllUsers(guid);
        var publicUsers = users.Select(user => (PublicUserDTO)user).ToList();
        return publicUsers;
    }
    
    [HttpGet("{userId}/chatrooms/{chatroomId}/messages")]
    public async Task<List<MessageModel>> ShowMessagesByChatroomId(Guid userId, Guid chatroomId)
    {
        return await _chatService.GetMessagesByChatroomId(chatroomId, userId);
    }
    
    [HttpGet("chatrooms")]
    public async Task<List<ChatRoomModel>> ShowChatroomsByUser(Guid userId)
    {
        return await _chatService.GetChatroomsByUserId(userId);
    }
    
    [HttpGet("matches")]
    public async Task<List<PublicUserDTO>> ShowMatchesByUser()
    {
        var currentUser  = Request.Cookies["id"];
        var guid = Guid.Parse(currentUser);
        return (await _userService.GetMatchesByUser(guid)).Select(user => (PublicUserDTO)user).ToList();
    }

    [HttpGet("{userId}")]
    public async Task<PublicUserDTO> ShowUserById(Guid userId)
    {
        return (await _ctrlLoveService.FindEntityById<UserModel>(userId));

    }
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<bool> SignInUser([FromBody] LoginCredentialsDTO details)
    {
        var user = await _userService.SignInUser(details.Email, details.Password);
        
        if (user == null) return false;
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Email)
        };
        
        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        CookieOptions cookieOptions = new CookieOptions();
        cookieOptions.Secure = true;
        Response.Cookies.Append("id", user.Id.ToString(), cookieOptions);
        
        await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)
            );
        
        return true;
    }

    [HttpGet("my-profile/{userId}")]
    public async Task<PrivateUserDTO> ShowOwnUserById(Guid userId)
    {
        return (await _userService.GetUserById(userId));

    }
    
    [HttpGet("logout")]
    public async Task LogoutUser()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    }
    
    [HttpDelete("{userId}")]
    public async Task<bool> DeleteUserById(Guid userId)
    {
        return await _userService.DeleteUserById(userId);
        
    }
    
    [HttpPut("{userId}")]
    public async Task<UserModel> UpdateUserById(Guid userId, [FromBody] ModifyUserDTO user)
    {
        Console.WriteLine(user);
        Console.WriteLine("miért");
        return await _userService.UpdateUserById(userId, user);
        
    }
    [AllowAnonymous]
    [HttpPost]
    public async Task<PrivateUserDTO> PostNewUser([FromBody] UserModel user)
    {
        Console.WriteLine(user.ToString());
        return await _userService.AddNewUser(user);
        
    }
}