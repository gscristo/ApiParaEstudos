using Dapper;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly IDataContext _dataContext;
        public UsersRepository(IDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Users> Login(string usuario, string senha)
        {
            string query = $"SELECT * FROM [dbo].[Users] WHERE Usuario = @usuario and Senha = @senha";

            var result = await _dataContext.Connection.QueryFirstOrDefaultAsync<Users>(query, new { usuario = usuario, senha = senha });

            _dataContext.Dispose();

            return result;
        }
    }
}
