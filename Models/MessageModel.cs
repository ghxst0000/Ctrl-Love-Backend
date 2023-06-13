using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CtrlLove.Models;
[Table("message")]
public class MessageModel
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public Guid ID { get; private set; }
    public UserModel Sender { get; private set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; private set; }

}