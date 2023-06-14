using CtrlLove.Service;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/api/v1/interests")]

public class InterestController :  ControllerBase
{
    private readonly IUserService _userService;

    public InterestController(IUserService userService)
    {
        _userService = userService;
    }
    
    
}