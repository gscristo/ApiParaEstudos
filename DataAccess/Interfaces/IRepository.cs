
namespace DataAccess.Interfaces
{
    using DapperExtensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRepository<T> where T : class
    {
        Guid Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<dynamic> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<T> GetByIdAsync(Guid Id, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<PaginationResponse<T>> GetAllAsyncPagination(int pageSize, int pageIndex, string sort, string direction, string tableName = "");
        Task<bool> UpdateAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> DeleteAsync(T entity, IDbTransaction transaction, int? commandTimeout = null);

    }
}
