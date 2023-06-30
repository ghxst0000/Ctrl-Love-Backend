using CtrlLove.Exceptions;
using CtrlLove.Models;
using CtrlLove.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CtrlLove.Service;

public class UserService : CtrlLoveService, IUserService
{

    public UserService(CtrlLoveContext context) : base(context)
    {
    }

    public async Task<List<UserModel>> GetAllUsers(Guid currentUser)
    {
        var user = await GetUserById(currentUser);
        var likedByCurrentUser = _context.UserModel
            .Where(u => u.Id == currentUser)
            .SelectMany(u => u.Likes)
            .Where(l => l.Liked)
            .Select(l => l.LikedUserId)
            .ToList();

        var usersNotLikedByCurrentUser = _context.UserModel
            .Include(u => u.Photos)
            .Include(u => u.Interests)
            .Where(u => u.Id != currentUser && !likedByCurrentUser.Contains(u.Id))
            .ToList();

        return usersNotLikedByCurrentUser;
    }

    public async Task<UserModel> GetUserByName(string name)
    {
        UserModel? user = await _context.UserModel.FirstOrDefaultAsync(u=>u.Name==name);
        return user;
    }
    
    public async Task<UserModel?> GetUserByEmail(string email)
    {
        UserModel? user = await _context.UserModel.FirstOrDefaultAsync(u=>u.Email==email);
        return user;
    }

    public async Task<UserModel> GetUserById(Guid id)
    {
        UserModel? user = await _context.UserModel.Include(user => user.Photos).FirstOrDefaultAsync(user => user.Id == id);
        if (user == null)
        {
            throw new IdNotFoundException($"The user with the Id {id} was not found.");
        }

        return user;
    }

    public async Task<UserModel> UpdateUserById(Guid userId, ModifyUserDTO modifiedUser)
    {
        UserModel existingUser = await GetUserById(userId);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Name = modifiedUser.Name;
        existingUser.Gender = modifiedUser.Gender;
        existingUser.MinimumAge = modifiedUser.MinimumAge;
        existingUser.MaximumAge = modifiedUser.MaximumAge;
        existingUser.Biography = modifiedUser.Biography;
        existingUser.Location = modifiedUser.Location;
        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<List<UserModel>> GetMatchesByUser(Guid userId)
    {
        List<UserModel> mutualLikes = new List<UserModel>();
        mutualLikes = _context.UserModel
                .Where(u1 => _context.UserModel
                    .Any(u2 => u2.Likes.Any(l => l.LikedByUserId == u1.Id && l.LikedUserId == u2.Id && l.Liked)))
                .ToList();

        return mutualLikes;
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
        UserModel? foundUser = await GetUserByEmail(user.Email);
        if (foundUser != null)
        {
            throw new EmailAlreadyInUseException("This email address already in taken!");
        }

        IPasswordHasher<UserModel> hasher = new PasswordHasher<UserModel>();
        var hashedPassword = hasher.HashPassword(user, user.Password);
        user.Password = hashedPassword;

        _context.UserModel.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserModel?> SignInUser(string detailsEmail, string detailsPassword)
    {
        var user = await GetUserByEmail(detailsEmail);

        if (user == null) return null;
        
        var passwordHasher = new PasswordHasher<UserModel>();

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, detailsPassword);
        
        if (result != PasswordVerificationResult.Success) return null;

        return user;
    }
}