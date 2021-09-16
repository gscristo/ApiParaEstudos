namespace DataAccess.Context
{
    using System.Data;
    using System.Threading.Tasks;
    public interface IDataContext
    {
        IDbConnection Connection { get; }
        Task<IDbConnection> CreateConnectionAsync();
        void Dispose();
    }
}
