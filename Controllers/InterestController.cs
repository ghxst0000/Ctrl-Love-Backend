using CtrlLove.Models;
using CtrlLove.Service;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;

[ApiController]
[Route("/api/v1/interests")]

public class InterestController :  ControllerBase
{
    private readonly IInterestService _interestService;

    public InterestController(IInterestService interestService)
    {
        _interestService = interestService;
    }

    [HttpGet]
    public async Task<List<InterestModel>> GetAllInterests()
    {
        return await _interestService.GetAllInterest();
    }

    [HttpPost]
    public async Task<InterestModel> AddInterest([FromBody] string interest)
    {
        return await _interestService.AddInterest(interest);
    }

    [HttpPost("/add/{userId:Guid}")]
    public async Task<List<InterestModel>> AddInterestToUser(Guid userId, [FromBody] Guid interestId)
    {
        return await _interestService.AddInterestToUser(interestId, userId);
    }
    
    [HttpDelete("/remove/{userId:Guid}")]
    public async Task<List<InterestModel>> RemoveInterestFromUser(Guid userId, [FromBody] Guid interestId)
    {
        return await _interestService.RemoveInterestFromUser(interestId, userId);
    }
}