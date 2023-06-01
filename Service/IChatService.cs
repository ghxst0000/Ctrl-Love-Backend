using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IChatService
{
    List<MessageModel>  GetMessagesByChatroomId(Guid id);
    List<ChatRoomModel> GetChatroomsByUserID(Guid userId);
}