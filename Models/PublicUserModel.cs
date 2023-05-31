namespace CtrlLove.Models;

public class PublicUserModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public byte Age { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ISet<string> Photos { get; set; }
    public ISet<string> Interests { get; set; }

    public PublicUserModel(Guid id, string name, string biography, byte age, string location, Gender gender, ISet<string> photos, ISet<string> interests)
    {
        ID = id;
        Name = name;
        Biography = biography;
        Age = age;
        Location = location;
        Gender = gender;
        Photos = photos;
        Interests = interests;
    }
}