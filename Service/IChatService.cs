using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IChatService
{
    IActionResult GetMessagesByChatroomId(string id);
    IActionResult GetChatroomsByUserID(string userId);
}