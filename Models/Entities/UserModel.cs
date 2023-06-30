using System.ComponentModel;
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
    [Required]
    public string Name { get; set; }
    
    public string? Biography { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    public string? Location { get; set; }
    [Required]
    public Gender Gender { get; set; }
    public ICollection<PhotoModel>? Photos { get; set; }
    public List<InterestModel>? Interests { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public virtual List<LikeModel>? Likes { get; } = new List<LikeModel>();
    public DateTime? Created { get; set; }
    [DefaultValue(18)]
    public int MinimumAge { get; set; }
    [DefaultValue(200)]
    public int MaximumAge { get; set; }
    public List<Gender>? DesiredGenders { get; set; }
    public List<string> Roles { get; set; } = new List<string> {"User"};

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

        if (!DesiredGenders.Contains(user.Gender) && user.Gender != null)
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

    public static implicit operator PublicUserDTO(UserModel user)
    {
        return new PublicUserDTO(user.Id, user.Name, user.Biography, user.BirthDate, user.Location,
            user.Gender, user.Photos, user.Interests);
    }
    
    public static implicit operator PrivateUserDTO(UserModel user)
    {
        return new PrivateUserDTO(
            user.Id, user.Name, user.Biography, user.BirthDate, user.Location,
            user.Gender, user.Photos, user.Interests, user.Email, user.Likes,
            user.Created, user.MinimumAge, user.MaximumAge, user.DesiredGenders);
    }
}