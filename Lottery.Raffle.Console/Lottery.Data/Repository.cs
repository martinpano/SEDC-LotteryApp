using Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lottery.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> DbSet;
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
            _dbContext = dbContext;

        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
