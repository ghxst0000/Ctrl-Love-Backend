using CtrlLove.DAL;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public class ChatService : IChatService
{
    private readonly IRepository<ChatRoomModel, Guid> _repository;

    public ChatService(IRepository<ChatRoomModel, Guid> repository)
    {
        _repository = repository;
    }

    public List<MessageModel> GetMessagesByChatroomId(Guid id)
    {
        return _repository.GetElementById(id).messages;

    }

    public List<ChatRoomModel> GetChatroomsByUserID(Guid userId)
    {
        List<ChatRoomModel> allRooms = _repository.GetAll();
        
        return allRooms.Where(room => room.Participants.Contains(userId)).ToList();

    }
}