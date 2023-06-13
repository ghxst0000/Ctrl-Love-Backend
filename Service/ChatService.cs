using CtrlLove.Exceptions;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public class ChatService : IChatService
{
    private CtrlLoveContext _context { get; set; }

    public ChatService(CtrlLoveContext context)
    {
        _context = context;
    }

    public async Task<List<MessageModel>> GetMessagesByChatroomId(Guid roomId, Guid userId)
    {
        ChatRoomModel room = await GetChatRoomById(roomId);
        if (room.IncludesThisParticipant(userId))
        {
            return room.Messages;
        }

        throw new PermissionDeniedException(
            $"The user with the ID {userId} don't have permission to the chat room with ID {roomId}.");


    }


    public async Task<List<ChatRoomModel>> GetChatroomsByUserId(Guid userId)
    {
        List<ChatRoomModel> allRooms = _context.ChatRoomModels.ToList();
        
        return allRooms.Where(room => room.Participants.Any(p => p.Id.Equals(userId))).ToList();

    }


    public async Task<ChatRoomModel> GetChatRoomById(Guid roomId)
    {
        var room = _context.ChatRoomModels.FirstOrDefault(model => model.Id.Equals(roomId));
        if (room == null)
        {
            throw new IdNotFoundException($"The chat room with the Id {roomId} was not found.");
        }

        return room;
    }
}