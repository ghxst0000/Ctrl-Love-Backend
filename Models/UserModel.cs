using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CtrlLove.Models;
[Table("private-user")]
public class UserModel : PublicUserModel
{
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
}