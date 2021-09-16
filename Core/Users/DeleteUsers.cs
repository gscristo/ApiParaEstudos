using Core.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DeleteUsers : IDeleteUsers
    {
        IUsersRepository _usersRepository;

        public DeleteUsers(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async void Execute(Guid usersId)
        {
            var result = await _usersRepository.GetByIdAsync(usersId);

            //Arrumar esse trecho, tirar o null(se tira da erro no param de transaction)*
            await _usersRepository.DeleteAsync(result, null); 
        }
    }
}
