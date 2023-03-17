using HRGS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRGS.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity,new()
    {

        Task<int> AddAsync(T entity);
        int Add(T entity);

        Task<int> EditAsync(T entity);
        int Edit(T entity);

        Task<int> DeleteAsync(T entity);
        int Delete(T entity);


        Task<List<T>> QueryAsync();
        List<T> Query();

        Task<List<T>> QueryAsync(Expression<Func<T,bool>> whereLambda);
        List<T> Query(Expression<Func<T, bool>> whereLambda);

        Task<T> QueryAsync(Guid id);
        T Query(Guid id);
    }
}
