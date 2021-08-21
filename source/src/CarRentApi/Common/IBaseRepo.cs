using System.Collections.Generic;

namespace CarRentApi.Common
{
    public interface IBaseRepo<T>
    {
        List<T> GetAll();
        
        T GetById(int id);
        
        T Add(T obj);
        
        T Update(T obj);
        
        void Delete(T obj);
    }
}
