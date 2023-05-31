using CtrlLove.Models;

namespace CtrlLove.DAL;

public interface IUserRepository
{
    List<UserModel> GetAll();
    UserModel GetUserById(string id);
    List<UserModel> GetMatchesByUser(string userId);
}