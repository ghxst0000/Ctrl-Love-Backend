using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CtrlLove.Models;
[Table("private-user")]
public class UserModel : PublicUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public ISet<Guid> Likes { get; set; }
    public ISet<Guid> Dislikes { get; set; }
    public DateTime Created { get; set; }
    public AgeRange AgeRange { get; set; } = new AgeRange();
    public ISet<Gender> DesiredGenders { get; set; }

    
    
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

        if (!AgeRange.IsInRange(user.CalculateAge()))
        {
            return false;
        }

        if (!user.AgeRange.IsInRange(CalculateAge()))
        {
            return false;
        }

        return true;
    }
}