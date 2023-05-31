namespace CtrlLove.Models;

public class MessageModel
{
    public Guid ID { get; private set; }
    public UserModel Sender { get; private set; }
    public string Body { get; set; }
    public ChatRoomModel ChatRoom { get; private set; }
    public DateTime Timestamp { get; private set; }

    public MessageModel(Guid id, UserModel sender, string body, ChatRoomModel chatRoom, DateTime timestamp)
    {
        ID = id;
        Sender = sender;
        Body = body;
        ChatRoom = chatRoom;
        Timestamp = timestamp;
    }
}