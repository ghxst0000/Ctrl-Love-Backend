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
    public List<InterestModel> Interests { get; set; }
    public string Email { get; set; }
    public List<LikeModel> Likes { get; set; }
    public List<LikeModel> Dislikes { get; set; }
    public DateTime Created { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public List<Gender> DesiredGenders { get; set; }

    public PrivateUserDTO(Guid id, string name, string biography, DateTime birthDate, string location, Gender gender, ICollection<PhotoModel> photos, List<InterestModel> interests, string email, List<LikeModel> likes, DateTime created, int minimumAge, int maximumAge, List<Gender> desiredGenders)
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
        Likes = likes.Where(like=>like.Liked).ToList();
        Dislikes = likes.Where(like=>!like.Liked).ToList();
        Created = created;
        MinimumAge = minimumAge;
        MaximumAge = maximumAge;
        DesiredGenders = desiredGenders;
    }
    
    
}