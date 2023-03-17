using HRKJ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.IRepository
{
    public interface IBaseDal<T> where T : BaseEntity, new()
    {
        int Add(T model);
        Task<int> AddAsync(T model);

        int Edit(T model);
        Task<int> EditAsync(T model);

        int Delete(T model);
        Task<int> DeleteAsync(T model);

        List<T> Query();
        Task<List<T>> QueryAsync();

        List<T> Query(Expression<Func<T, bool>> whereLambda);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> whereLambda);

        T Query(int id);
        Task<T> QueryAsync(int id);
    }
}
