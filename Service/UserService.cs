using CtrlLove.DAL;
using CtrlLove.Models;

namespace CtrlLove.Service;

public class UserService : IUserService
{
    private readonly IRepository<UserModel, Guid> _repository;

    public UserService(IRepository<UserModel, Guid> repository)
    {
        _repository = repository;
    }

    public List<UserModel> GetAllUsers()
    {
        return _repository.GetAll();
    }

    public UserModel GetUserById(Guid id)
    {
        return _repository.GetElementById(id);
    }

    public List<UserModel> GetMatchesByUser(Guid userId)
    {
        List<UserModel> allUsers = _repository.GetAll();
        UserModel activeUser = _repository.GetElementById(userId);
        List<UserModel> matchingUsers = allUsers.Where(user => !user.ID.Equals(userId) &&
                                                               activeUser.DesiredGenders.Contains(user.Gender) &&
                                                               user.DesiredGenders.Contains(activeUser.Gender) &&
                                                               activeUser.AgeRange.Bottom >= user.CalculateAge() &&
                                                               activeUser.AgeRange.Top <= user.CalculateAge() &&
                                                               user.AgeRange.Bottom >= activeUser.CalculateAge() &&
                                                               user.AgeRange.Top <= activeUser.CalculateAge()).ToList();
        
        //TODO: maybe sort by location and intersts machings?
        return matchingUsers;
    }
}