using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CtrlLove.Models;
[Table("public-user")]
public class PublicUserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Photo> Photos { get; set; }
    public List<Interest> Interests { get; set; }
    
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