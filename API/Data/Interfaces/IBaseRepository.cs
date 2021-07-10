using System;
using System.Collections.Generic;

namespace API.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(Guid id);
        ICollection<T> List();
    }
}