using CtrlLove.DAL;
using CtrlLove.Exceptions;
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
        UserModel? user = _repository.GetElementById(id);
        if (user == null)
        {
            throw new IdNotFoundException($"The user with the Id {id} was not found.");
        }

        return user;
    }

    public List<UserModel> GetMatchesByUser(Guid userId)
    {
        List<UserModel> allUsers = _repository.GetAll();
        UserModel activeUser = GetUserById(userId);
        List<UserModel> matchingUsers = allUsers.Where(user => user.IsMatch(activeUser)).ToList();
        
        //TODO: maybe sort by location and intersts machings?
        return matchingUsers;
    }

    public bool DeleteUserById(Guid userId)
    {
        return _repository.DeleteElement(GetUserById(userId));
    }
}