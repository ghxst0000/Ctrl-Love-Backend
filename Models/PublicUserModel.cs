namespace CtrlLove.Models;

public class PublicUserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ISet<string> Photos { get; set; }
    public ISet<string> Interests { get; set; }

    public PublicUserModel(string name, string biography, DateTime birthDate, string location, Gender gender, ISet<string> photos, ISet<string> interests)
    {
        Id = Guid.NewGuid();
        Name = name;
        Biography = biography;
        BirthDate = birthDate;
        Location = location;
        Gender = gender;
        Photos = photos;
        Interests = interests;
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