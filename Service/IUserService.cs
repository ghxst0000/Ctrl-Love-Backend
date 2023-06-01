using CtrlLove.DAL;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    List<UserModel> GetAllUsers();
    UserModel? GetUserById(Guid id);
    List<UserModel> GetMatchesByUser(Guid userId);
    bool DeleteUserById(Guid userId);
}