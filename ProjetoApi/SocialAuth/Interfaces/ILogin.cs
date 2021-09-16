using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Users.Interfaces
{
    public interface ILogin
    {
        Task<Model.Users> Execute(Model.Users user);
    }
}
