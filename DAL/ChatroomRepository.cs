using CtrlLove.Models;

namespace CtrlLove.DAL;

public class ChatroomRepository : IRepository<ChatRoomModel, Guid>
{

    public List<ChatRoomModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public ChatRoomModel GetElementById(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool AddNewElement(object o)
    {
        throw new NotImplementedException();
    }

    public bool DeleteElement(ChatRoomModel chatRoom)
    {
        throw new NotImplementedException();
    }

    public bool UpdateElement(object old, object updated)
    {
        throw new NotImplementedException();
    }
}