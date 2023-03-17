global using Entity.Models;
using System.Linq.Expressions;

namespace IRepository
{
    public interface IBaseDal<T> where T : BaseEntity,new()
    {
        Task<int> AddAsync(T model,bool isSave=true);
        Task<int> EditAsync(T model, bool isSave = true);
        Task<int> DeleteAsync(T model, bool isSave = true);
        Task<int> SaveData();

        Task<List<T>> QueryAsync();
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> whereLambda);
        Task<T> QueryAsync(int id);    
    }
}