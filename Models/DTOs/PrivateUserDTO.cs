namespace CtrlLove.Models.DTOs;

public class PrivateUserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ICollection<PhotoModel> Photos { get; set; }
    public List<Interest> Interests { get; set; }
    public string Email { get; set; }
    public List<Guid> Likes { get; set; }
    public List<Guid> Dislikes { get; set; }
    public DateTime Created { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public List<Gender> DesiredGenders { get; set; }

    public PrivateUserDTO(Guid id, string name, string biography, DateTime birthDate, string location, Gender gender, ICollection<PhotoModel> photos, List<Interest> interests, string email, List<Guid> likes, List<Guid> dislikes, DateTime created, int minimumAge, int maximumAge, List<Gender> desiredGenders)
    {
        Id = id;
        Name = name;
        Biography = biography;
        BirthDate = birthDate;
        Location = location;
        Gender = gender;
        Photos = photos;
        Interests = interests;
        Email = email;
        Likes = likes;
        Dislikes = dislikes;
        Created = created;
        MinimumAge = minimumAge;
        MaximumAge = maximumAge;
        DesiredGenders = desiredGenders;
    }
}