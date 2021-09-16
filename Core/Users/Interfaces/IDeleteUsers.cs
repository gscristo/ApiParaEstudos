using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDeleteUsers
    {
         void Execute(Guid usersId);
    }
}
