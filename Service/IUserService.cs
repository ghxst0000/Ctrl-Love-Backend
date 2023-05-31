using CtrlLove.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    IActionResult GetAllUsers();
    IActionResult GetUserById(string id);
}