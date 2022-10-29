using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Create(T t);
        int Update(T t);
        int Delete(int id);

      

    }
}
