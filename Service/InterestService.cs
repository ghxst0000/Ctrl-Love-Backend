using CtrlLove.Models;
using Microsoft.EntityFrameworkCore;

namespace CtrlLove.Service;

public class InterestService : CtrlLoveService ,IInterestService
{
    protected InterestService(CtrlLoveContext context) : base(context)
    {
    }
    
    public async Task<List<InterestModel>> GetAllInterest()
    {
        return await _context.Interests.ToListAsync();
    }

    public async Task<InterestModel> AddInterest(string interest)
    {
        var newInterest =  _context.Interests.Add(new InterestModel { Name = interest }).Entity;
        await _context.SaveChangesAsync();
        return newInterest;

    }

    public async Task<List<InterestModel>> AddInterestToUser(Guid interestId, Guid userId)
    {
        var interest = FindEntityById<InterestModel>(interestId).Result;
        var userInterests = FindEntityById<UserModel>(userId).Result.Interests;
        userInterests.Add(interest);
        _context.SaveChangesAsync();
        return userInterests;
    }

    public async Task<List<InterestModel>> RemoveInterestFromUser(Guid interestId, Guid userId)
    {
        throw new NotImplementedException();
    }

    
}