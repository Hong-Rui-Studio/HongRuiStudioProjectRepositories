global using IRepository;
global using Entity.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class BaseDal<T> : IBaseDal<T> where T : BaseEntity, new()
    {
        private MyContext _cxt;
        public BaseDal(MyContext cxt)
        {
            _cxt = cxt;
        }


        public async Task<int> AddAsync(T model, bool isSave = true)
        {
            _cxt.Entry(model).State = EntityState.Added;
            if(isSave)
                return await _cxt.SaveChangesAsync();
            return 0;
        }

        public async Task<int> DeleteAsync(T model, bool isSave = true)
        {
            _cxt.Entry(model).State = EntityState.Deleted;
            if (isSave)
                return await _cxt.SaveChangesAsync();
            return 0;
        }

        public async Task<int> EditAsync(T model, bool isSave = true)
        {
            _cxt.Entry(model).State = EntityState.Modified;
            if (isSave)
                return await _cxt.SaveChangesAsync();
            return 0;
        }

        public async Task<List<T>> QueryAsync()
        {
            return await _cxt.Set<T>().ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _cxt.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<T> QueryAsync(int id)
        {
            return await _cxt.Set<T>().FindAsync(id);
        }

        public async Task<int> SaveData()
        {
            return await _cxt.SaveChangesAsync();
        }
    }
}