namespace CtrlLove.Models;

public class ChatRoomModel
{
    public Guid Id { get; set; }
    public ISet<Guid> Participants { get; set; }
    public List<MessageModel> Messages { get; }

    public ChatRoomModel(Guid id, ISet<Guid> participants)
    {
        Id = id;
        Participants = participants;
        Messages = new List<MessageModel>();
    }

    public bool IncludesThisParticipant(Guid id)
    {
        return Participants.Contains(id);
    }
}