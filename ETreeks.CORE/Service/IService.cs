using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface IService<T>
    {
        /*aaaaaa*/
        List<T> GetAll();

        T GetById(int id);
        bool Create(T course);
        bool Update(T course);
        bool Delete(int id);
    }
}
