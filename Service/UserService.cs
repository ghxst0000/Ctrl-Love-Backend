using CtrlLove.DAL;
using CtrlLove.Models;

namespace CtrlLove.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public List<UserModel> GetAllUsers()
    {
        return _repository.GetAll();
    }

    public UserModel GetUserById(string id)
    {
        return _repository.GetUserById(id);
    }

    public List<UserModel> GetMatchesByUser(string userId)
    {
        return _repository.GetMatchesByUser(userId);
    }
}