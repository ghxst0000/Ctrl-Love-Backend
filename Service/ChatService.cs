using CtrlLove.DAL;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public class ChatService : IChatService
{
    private readonly IChatroomRepository _repository;

    public ChatService(IChatroomRepository repository)
    {
        _repository = repository;
    }

    public List<MessageModel> GetMessagesByChatroomId(string id)
    {
        return _repository.GetMessagesByChatroomId(id);
    }

    public List<ChatRoomModel> GetChatroomsByUserID(string userId)
    {
        return _repository.GetChatroomsByUserID(userId);
    }
}