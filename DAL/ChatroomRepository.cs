using CtrlLove.Models;

namespace CtrlLove.DAL;

public class ChatroomRepository : IChatroomRepository
{
    public List<MessageModel> GetMessagesByChatroomId(string id)
    {
        throw new NotImplementedException();
    }

    public List<ChatRoomModel> GetChatroomsByUserID(string userId)
    {
        throw new NotImplementedException();
    }
}