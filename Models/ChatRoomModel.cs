namespace CtrlLove.Models;

public class ChatRoomModel
{
    public Guid ID { get; set; }
    public UserModel[] Participants { get; set; }

    public ChatRoomModel(Guid id, UserModel[] participants)
    {
        ID = id;
        Participants = participants;
    }
}