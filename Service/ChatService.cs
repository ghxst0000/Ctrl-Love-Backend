using CtrlLove.DAL;
using CtrlLove.Exceptions;
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

    public List<MessageModel> GetMessagesByChatroomId(Guid roomId, Guid userId)
    {
        ChatRoomModel room = GetChatRoomById(roomId);
        if (room.IncludesThisParticipant(userId))
        {
            return GetChatRoomById(roomId).Messages;
        }

        throw new PermissionDeniedException(
            $"The user with the ID {userId} don't have permission to the chat room with ID {roomId}.");


    }

    public List<ChatRoomModel> GetChatroomsByUserId(Guid userId)
    {
        List<ChatRoomModel> allRooms = _repository.GetAll();
        
        return allRooms.Where(room => room.Participants.Contains(userId)).ToList();

    }

    public ChatRoomModel GetChatRoomById(Guid roomId)
    {
        ChatRoomModel? room = _repository.GetElementById(roomId);
        if (room == null)
        {
            throw new IdNotFoundException($"The chat room with the Id {roomId} was not found.");
        }

        return room;
    }
}