using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IChatService
{
    List<MessageModel>  GetMessagesByChatroomId(string id);
    List<ChatRoomModel> GetChatroomsByUserID(string userId);
}