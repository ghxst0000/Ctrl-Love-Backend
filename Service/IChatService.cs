using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IChatService
{
    Task<List<MessageModel>>  GetMessagesByChatroomId(Guid roomId, Guid userId);
    Task<List<ChatRoomModel>> GetChatroomsByUserId(Guid userId);
}