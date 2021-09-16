namespace DataAccess.Context
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public class DataContext : IDataContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DataContext(string connectionString) => _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            return sqlConnection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}