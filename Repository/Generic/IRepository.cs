using System.Collections.Generic;
using DotNetCoreEF.Model.Base;

namespace DotNetCoreEF.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}