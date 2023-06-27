
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

    public async Task<UserModel> GetUserByName(string name)
    {
        UserModel? user = await _context.UserModel.FirstOrDefaultAsync(u=>u.Name==name);
        return user;
    }
    
    public async Task<UserModel> GetUserByEmail(string email)
    {
        UserModel? user = await _context.UserModel.FirstOrDefaultAsync(u=>u.Email==email);
        return user;
    }

    public async Task<UserModel> GetUserById(Guid id)
    {
        UserModel? user = await _context.UserModel.FindAsync(id);
        if (user == null)
        {
            throw new IdNotFoundException($"The user with the Id {id} was not found.");
        }

        return user;
    }

    public async Task<List<UserModel>> GetMatchesByUser(Guid userId)
    {
        List<UserModel> allUsers = await _context.UserModel.ToListAsync();
        UserModel activeUser = await GetUserById(userId);
        List<UserModel> matchingUsers = allUsers.Where(user => user.IsMatch(activeUser)).ToList();
        
        //TODO: maybe sort by location and intersts machings?
        return matchingUsers;
    }

    public async Task<bool> DeleteUserById(Guid userId)
    {
        UserModel user = await GetUserById(userId);
        EntityEntry<UserModel> response = _context.UserModel.Remove(user);
        await _context.SaveChangesAsync();
        return !response.Equals(null);
    }

    public async Task<UserModel> AddNewUser(UserModel user)
    {
        UserModel foundUser = await GetUserByEmail(user.Email);
        if (foundUser != null)
        {
            throw new EmailAlreadyInUseException("This email address already in taken!");
        }
        _context.UserModel.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}