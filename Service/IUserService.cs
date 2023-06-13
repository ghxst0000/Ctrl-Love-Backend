
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> GetUserById(Guid id);
    Task<List<UserModel>> GetMatchesByUser(Guid userId);
    Task<bool> DeleteUserById(Guid userId);
    Task<UserModel> AddNewUser(UserModel user);
}