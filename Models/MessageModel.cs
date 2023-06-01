namespace CtrlLove.Models;

public class MessageModel
{
    public Guid ID { get; private set; }
    public UserModel Sender { get; private set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; private set; }

    public MessageModel(Guid id, UserModel sender, string body, DateTime timestamp)
    {
        ID = id;
        Sender = sender;
        Body = body;
        Timestamp = timestamp;
    }
}