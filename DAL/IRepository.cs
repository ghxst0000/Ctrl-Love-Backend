﻿using CtrlLove.Models;

namespace CtrlLove.DAL;

public interface IRepository<T, ID>
{
    List<T> GetAll();
    T? GetElementById(ID id);
    bool AddNewElement(object o);
    bool DeleteElement(T type);
    bool UpdateElement(object old, object updated);
}