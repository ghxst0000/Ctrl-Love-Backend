using CtrlLove.Models;

namespace CtrlLove.Service;

public interface IInterestService
{
    Task<List<InterestModel>> GetAllInterest();
    Task<InterestModel> AddInterest(string interest);
    Task<List<InterestModel>> AddInterestToUser(Guid interestId, Guid userId);
    Task<List<InterestModel>> RemoveInterestFromUser(Guid interestId, Guid userId);
}