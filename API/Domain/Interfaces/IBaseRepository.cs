using System;
using System.Collections.Generic;

namespace API.Domain.Interfaces
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