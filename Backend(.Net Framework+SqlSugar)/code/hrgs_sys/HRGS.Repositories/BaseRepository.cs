using HRGS.Entities;
using HRGS.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SqlSugar;
using System.Configuration;
namespace HRGS.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {

        private SqlSugarClient _client;
        public BaseRepository()
        {
            _client = new SqlSugarClient(new ConnectionConfig 
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SqlSugarConStr"].ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            });
        }


        public int Add(T entity)
        {
            return _client.Insertable<T>(entity).ExecuteCommand();
        }

        public async Task<int> AddAsync(T entity)
        {
            return await _client.Insertable<T>(entity).ExecuteCommandAsync();
        }

        public int Delete(T entity)
        {
            return _client.Deleteable<T>(entity).ExecuteCommand();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await  _client.Deleteable<T>(entity).ExecuteCommandAsync();
        }

        public int Edit(T entity)
        {
            return _client.Updateable<T>(entity).ExecuteCommand();
        }

        public async Task<int> EditAsync(T entity)
        {
            return await _client.Updateable<T>(entity).ExecuteCommandAsync();
        }

        public List<T> Query()
        {
            return _client.Queryable<T>().ToList();
        }

        public List<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            return _client.Queryable<T>().Where(whereLambda).ToList();
        }

        public T Query(Guid id)
        {
            return _client.Queryable<T>().First(x => x.Id == id);
        }

        public async Task<List<T>> QueryAsync()
        {
            return await  _client.Queryable<T>().ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await  _client.Queryable<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<T> QueryAsync(Guid id)
        {
            return await  _client.Queryable<T>().FirstAsync(x => x.Id == id);
        }
    }
}
