using CtrlLove.Models;

namespace CtrlLove.DAL;

public interface IRepository<T, ID>
{
    List<T> GetAll();
    T? GetElementById(ID id);
    bool AddNewElement(T type);
    bool DeleteElement(T type);
    bool UpdateElement(object old, object updated);
}