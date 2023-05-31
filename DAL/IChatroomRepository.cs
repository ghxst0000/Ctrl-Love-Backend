using CtrlLove.Models;

namespace CtrlLove.DAL;

public interface IChatroomRepository
{
    List<MessageModel> GetMessagesByChatroomId(string id);
    List<ChatRoomModel> GetChatroomsByUserID(string userId);
}