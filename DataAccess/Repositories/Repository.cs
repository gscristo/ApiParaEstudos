using Dapper;
using DapperExtensions;
using DataAccess.Context;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class Repository<T> : IRepository<T> where T : class
    {
        private IDataContext _dataContext { get; set; }

        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Guid Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = _dataContext.Connection.Insert(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<T> GetByIdAsync(Guid Id, IDbTransaction transaction = null, int? commandTimeout = null)
        {

            var result = await _dataContext.Connection.GetAsync<T>(Id, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.GetListAsync<T>(predicate, sort, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<dynamic> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.InsertAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<bool> UpdateAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.UpdateAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<bool> DeleteAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.DeleteAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<PaginationResponse<T>> GetAllAsyncPagination(int pageSize, int pageIndex, string sort, string direction, string tableName = "")
        {
            string table = typeof(T).Name;

            if (!string.IsNullOrEmpty(tableName))
                table = tableName;

            string defaultSort = $"{table}Id";
            string defaultDirection = "DESC";

            if (!string.IsNullOrEmpty(sort))
                defaultSort = sort;

            if (!string.IsNullOrEmpty(direction))
                defaultDirection = direction;

            string query = $@"SELECT *, COUNT({table}Id) OVER() Id
                            FROM {table} 
                            ORDER BY {defaultSort} {defaultDirection}
                            OFFSET(@PageIndex - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY";

            using (IDbConnection conn = await _dataContext.CreateConnectionAsync())
            {
                int totalRecords = 0;

                var result = await conn.QueryAsync<T, int, T>(query, (entity, totalCount) =>
                {
                    totalRecords = totalCount;
                    return entity;
                },
                new
                {
                    PageSize = pageSize,
                    PageIndex = pageIndex
                },
                splitOn: "Id");

                return new PaginationResponse<T>()
                {
                    TotalRecords = totalRecords,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    DataList = result
                };
            }
        }
    }
}
