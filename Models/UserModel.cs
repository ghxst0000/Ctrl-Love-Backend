namespace CtrlLove.Models;

public class UserModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ISet<Guid> Likes { get; set; }
    public ISet<Guid> Dislikes { get; set; }
    public string Biography { get; set; }
    public byte Age { get; set; }
    public DateTime Created { get; set; }
    public string Location { get; set; }
    public byte[] AgeRange { get; set; } = new byte[2];
    public Gender Gender { get; set; }
    public ISet<Gender> DesiredGenders { get; set; }
    public ISet<string> Photos { get; set; }
    public ISet<string> Interests { get; set; }

    public UserModel(
        Guid id, 
        string name, 
        string email,
        string password, 
        ISet<Guid> likes,
        ISet<Guid> dislikes, 
        string biography, 
        byte age, 
        DateTime created, 
        string location, 
        Gender gender,
        ISet<Gender> desiredGenders, 
        ISet<string> photos, 
        ISet<string> interests)
    {
        ID = id;
        Name = name;
        Email = email;
        Password = password;
        Likes = likes;
        Dislikes = dislikes;
        Biography = biography;
        Age = age;
        Created = created;
        Location = location;
        Gender = gender;
        DesiredGenders = desiredGenders;
        Photos = photos;
        Interests = interests;
    }
}