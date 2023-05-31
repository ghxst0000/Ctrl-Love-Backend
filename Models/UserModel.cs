namespace CtrlLove.Models;

public class UserModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid[] Likes { get; set; }
    public Guid[] Dislikes { get; set; }
    public string Biography { get; set; }
    public byte Age { get; set; }
    public DateTime Created { get; set; }
    public string Location { get; set; }
    public byte[] AgeRange { get; set; } = new byte[2];
    public Gender Gender { get; set; }
    public Gender[] DesiredGenders { get; set; }
    public string[] Photos { get; set; }
    public string[] Interests { get; set; }

    public UserModel(
        Guid id, 
        string name, 
        string email,
        string password, 
        Guid[] likes,
        Guid[] dislikes, 
        string biography, 
        byte age, 
        DateTime created, 
        string location, 
        Gender gender,
        Gender[] desiredGenders, 
        string[] photos, 
        string[] interests)
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