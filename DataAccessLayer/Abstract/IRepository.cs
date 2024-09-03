using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T item);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T item);
        void Update(T item);
        List<T> ListFiltr(Expression<Func<T, bool>> filter);
    }
}
