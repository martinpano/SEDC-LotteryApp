using Lottery.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data
{
    public interface IRepository<T> where T : IEntity
    {
        void Insert(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        T GetById(int id);

    }
}
