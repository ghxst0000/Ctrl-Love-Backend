
using CtrlLove.Exceptions;
using CtrlLove.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CtrlLove.Service;

public class UserService : CtrlLoveService, IUserService
{

    public UserService(CtrlLoveContext context) : base(context)
    {
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _context.UserModel.ToListAsync();
    }

    public async Task<List<UserModel>> GetMatchesByUser(Guid userId)
    {
        List<UserModel> allUsers = await _context.UserModel.ToListAsync();
        UserModel activeUser = await FindEntityById<UserModel>(userId);
        List<UserModel> matchingUsers = allUsers.Where(user => user.IsMatch(activeUser)).ToList();
        
        //TODO: maybe sort by location and intersts machings?
        return matchingUsers;
    }

    public async Task<bool> DeleteUserById(Guid userId)
    {
        UserModel user = await FindEntityById<UserModel>(userId);
        EntityEntry<UserModel> response = _context.UserModel.Remove(user);
        await _context.SaveChangesAsync();
        return !response.Equals(null);
    }

    public async Task<UserModel> AddNewUser(UserModel user)
    {
        _context.UserModel.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}