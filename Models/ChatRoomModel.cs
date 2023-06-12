using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CtrlLove.Models;
[Table("chatroom")]
public class ChatRoomModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public ISet<UserModel> Participants { get; set; }
    public List<MessageModel> Messages { get; }

    public bool IncludesThisParticipant(Guid id)
    {
        return Participants.Any(p => p.Id.Equals(id));
    }
}