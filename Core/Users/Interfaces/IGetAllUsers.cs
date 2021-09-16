using Core.Model;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGetAllUsers
    {
        Task<PaginationResponse<Users.Model.Users>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "");
    }
}
