using CtrlLove.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(string id);
    List<User> GetMatchesByUser(string userId);
}