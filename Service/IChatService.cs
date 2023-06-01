using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IChatService
{
    List<MessageModel>  GetMessagesByChatroomId(Guid roomId, Guid userId);
    List<ChatRoomModel> GetChatroomsByUserId(Guid userId);
    ChatRoomModel GetChatRoomById(Guid roomId);
}