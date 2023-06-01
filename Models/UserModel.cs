namespace CtrlLove.Models;

public class UserModel : PublicUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public ISet<Guid> Likes { get; set; }
    public ISet<Guid> Dislikes { get; set; }
    public DateTime Created { get; set; }
    public AgeRange AgeRange { get; set; } = new AgeRange();
    public ISet<Gender> DesiredGenders { get; set; }

    public UserModel (
        string name, 
        string email,
        string password, 
        ISet<Guid> likes,
        ISet<Guid> dislikes, 
        string biography, 
        DateTime birthDate, 
        DateTime created, 
        string location, 
        Gender gender,
        ISet<Gender> desiredGenders, 
        ISet<string> photos, 
        ISet<string> interests) : 
        base(
            name, 
            biography, 
            birthDate, 
            location,
            gender,
            photos, 
            interests)
    {
        Email = email;
        Password = password;
        Likes = likes;
        Dislikes = dislikes;
        Created = created;
        DesiredGenders = desiredGenders;
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