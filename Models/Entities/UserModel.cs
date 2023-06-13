using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    public ICollection<Photo> Photos { get; set; }
    public List<Interest> Interests { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Guid> Likes { get; set; }
    public List<Guid> Dislikes { get; set; }
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
}