using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeBotel.Repository.IRepositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        List<TEntity> GetAll();
        void Remove(TEntity entity);
        TEntity Find(params object[] keyValues);
    }
}
