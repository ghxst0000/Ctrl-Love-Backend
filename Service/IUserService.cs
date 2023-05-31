using CtrlLove.DAL;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    List<UserModel> GetAllUsers();
    UserModel GetUserById(string id);
    List<UserModel> GetMatchesByUser(string userId);
}