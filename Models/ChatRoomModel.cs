namespace CtrlLove.Models;

public class ChatRoomModel
{
    public Guid ID { get; set; }
    public ISet<UserModel> Participants { get; set; }

    public ChatRoomModel(Guid id, ISet<UserModel> participants)
    {
        ID = id;
        Participants = participants;
    }
    
    public ChatRoomModel(Guid id)
    {
        ID = id;
        Participants = new HashSet<UserModel>();
    }
}