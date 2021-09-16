using Core.Interfaces;
using Core.Model;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public class GetAllUsers : IGetAllUsers
    {
        IUsersRepository _usersRepository;

        public GetAllUsers(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<PaginationResponse<Users.Model.Users>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "")
        {
            List<Users.Model.Users> resultList = new List<Users.Model.Users>();

            var result = await _usersRepository.GetAllAsyncPagination(pageSize, pageIndex, sort, direction);

            foreach (var item in result.DataList)
            {
                resultList.Add(item);
            }

            return new PaginationResponse<Users.Model.Users>()
            {
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                ResultList = resultList
            };
        }

    }
}
