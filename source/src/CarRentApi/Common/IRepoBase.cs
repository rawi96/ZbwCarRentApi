using System.Collections.Generic;

namespace CarRentApi.Common
{
    public interface IRepoBase<T>
    {
        List<T> GetAll();
        
        T GetById(object id);
        
        T Add(T obj);
        
        T Update(T obj);
        
        void Delete(T obj);
    }
}
