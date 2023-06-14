using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CtrlLove.Models.DTOs;

namespace CtrlLove.Models;
public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ICollection<PhotoModel> Photos { get; set; }
    public List<InterestModel> Interests { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual List<LikeModel> Likes { get; } = new List<LikeModel>();
    public DateTime Created { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public List<Gender> DesiredGenders { get; set; }

    public bool IsInRange(int number)
    {
        return number <= MaximumAge && number >= MinimumAge;
    }
    
    public bool IsMatch(UserModel user)
    {
        if (user.Id.Equals(Id))
        {
            return false;
        }

        if (!DesiredGenders.Contains(user.Gender))
        {
            return false;
        }

        if (!user.DesiredGenders.Contains(Gender))
        {
            return false;
        }

        if (!IsInRange(user.CalculateAge()))
        {
            return false;
        }

        if (!user.IsInRange(CalculateAge()))
        {
            return false;
        }

        return true;
    }
    
    public int CalculateAge()
    {
        DateTime now = DateTime.Now;
        int years = now.Year - BirthDate.Year;

        if (BirthDate > now.AddYears(-years))
        {
            years--;
        }

        return years;
    }

    public static explicit operator PublicUserDTO(UserModel user)
    {
        return new PublicUserDTO(user.Id, user.Name, user.Biography, user.BirthDate, user.Location,
            user.Gender, user.Photos, user.Interests);
    }
    
    /*public static explicit operator PrivateUserDTO(UserModel user)
    {
        return new PrivateUserDTO(user.Id, user.Name, user.Biography, user.BirthDate, user.Location,
            user.Gender, user.Photos, user.Interests, user.Email, user.Likes.Select(u=>u.LikedByUserId).ToList(),
            user.Dislikes.Select(u=>u.li).ToList(), user.Created, user.MinimumAge, user.MaximumAge, user.DesiredGenders);
    }*/
}