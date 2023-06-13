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
    public List<Interest> Interests { get; set; }
}