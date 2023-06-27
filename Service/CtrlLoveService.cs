using CtrlLove.Exceptions;
using CtrlLove.Models;

namespace CtrlLove.Service;

public class CtrlLoveService
{
    protected readonly CtrlLoveContext _context;

    public CtrlLoveService(CtrlLoveContext context)
    {
        _context = context;
    }
    
    protected async Task<T> FindEntityById<T>(Guid id) where T : class
    {
        T? entity = _context.Set<T>().Find(id);

        if (entity is null)
        {
            throw new IdNotFoundException($"The {typeof(T).Name} with id {id} was not found.");
        }

        return entity;
    }
}