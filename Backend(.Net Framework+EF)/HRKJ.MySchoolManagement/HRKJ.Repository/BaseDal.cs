using HRKJ.Entity;
using HRKJ.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HRKJ.Repository
{
    public class BaseDal<T> : IBaseDal<T> where T : BaseEntity, new()
    {
        public SqlDbContext _db = new SqlDbContext();


        public int Add(T model)
        {
            _db.Entry(model).State = EntityState.Added;
            return _db.SaveChanges();
        }

        public async Task<int> AddAsync(T model)
        {
            _db.Entry(model).State = EntityState.Added;
            return await _db.SaveChangesAsync();
        }

        public int Delete(T model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public async Task<int> DeleteAsync(T model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            return await _db.SaveChangesAsync();
        }

        public int Edit(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public async Task<int> EditAsync(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public List<T> Query()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Where(whereLambda).ToList();
        }

        public T Query(int id)
        {
            return _db.Set<T>().Find(id);   
        }

        public async Task<List<T>> QueryAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<List<T>> QueryAsync(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return await _db.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<T> QueryAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
    }
}
