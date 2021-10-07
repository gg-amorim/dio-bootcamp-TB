using System.Collections.Generic;

namespace APP.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> GetAll();

        T GetById(int id);

        void PostObj(T obj);

        void DeleteObj(int id);

        void UpdadeObj(int id, T obj);

        int NextId();
    }
}