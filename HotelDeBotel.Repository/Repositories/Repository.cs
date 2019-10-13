using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Repository.IRepositories;

namespace HotelDeBotel.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return Set.Find(keyValues);
        }

        protected DbSet<TEntity> Set => _context.Set<TEntity>();
    }
}
