using CtrlLove.Exceptions;
using CtrlLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public class ChatService : CtrlLoveService, IChatService
{

    public ChatService(CtrlLoveContext context) : base(context)
    {
    }

    public async Task<List<MessageModel>> GetMessagesByChatroomId(Guid roomId, Guid userId)
    {
        ChatRoomModel room = await FindEntityById<ChatRoomModel>(roomId);
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
}