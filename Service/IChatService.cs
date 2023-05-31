using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Service;

public interface IMessageService
{
    IActionResult GetMessagesByChatroomId(string id);
}