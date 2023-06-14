namespace CtrlLove.Models.DTOs;

public class PublicUserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ICollection<PhotoModel> Photos { get; set; }
    public List<InterestModel> Interests { get; set; }

    public PublicUserDTO(Guid id, string name, string biography, DateTime birthDate, string location, Gender gender, ICollection<PhotoModel> photos, List<InterestModel> interests)
    {
        Id = id;
        Name = name;
        Biography = biography;
        BirthDate = birthDate;
        Location = location;
        Gender = gender;
        Photos = photos;
        Interests = interests;
    }
}