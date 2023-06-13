using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CtrlLove.Models;
[Table("photos")]
public class Photo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Url { get; set; }
    public UserModel user { get; set; }
}