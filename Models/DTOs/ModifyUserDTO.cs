namespace CtrlLove.Models.DTOs;

public class ModifyUserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public Gender Gender { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public string Location { get; set; }
}