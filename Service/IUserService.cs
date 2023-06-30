﻿
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IUserService
{
    Task<List<UserModel>> GetAllUsers(Guid currentUser);
    Task<List<UserModel>> GetMatchesByUser(Guid userId);
    Task<bool> DeleteUserById(Guid userId);
    Task<UserModel> AddNewUser(UserModel user);
    Task<UserModel?> SignInUser(string detailsEmail, string detailsPassword);
    Task<UserModel> GetUserById(Guid id);
}