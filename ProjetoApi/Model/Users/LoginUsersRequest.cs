using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Users
{
    public class LoginUsersRequest
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

       public static implicit operator Core.Users.Model.Users(LoginUsersRequest loginUsersRequest)
        {
            if (loginUsersRequest == null)
                return null;

            return new Core.Users.Model.Users
            {
                Usuario = loginUsersRequest.Usuario,
                Senha = loginUsersRequest.Senha
            };
        }
    }
}
