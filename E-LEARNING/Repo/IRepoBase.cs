using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Repo
{
     public interface IRepoBase<T> where T:class
    {
        List<T> GetAll();
        T GetByid(int id);
        bool IsExist(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();

    }
}
