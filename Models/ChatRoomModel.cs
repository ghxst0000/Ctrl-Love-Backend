namespace CtrlLove.Models;

public class ChatRoomModel
{
    public Guid Id { get; set; }
    public ISet<Guid> Participants { get; set; }
    public List<MessageModel> messages { get; }

    public ChatRoomModel(Guid id, ISet<Guid> participants)
    {
        Id = id;
        Participants = participants;
        messages = new List<MessageModel>();
    }
}