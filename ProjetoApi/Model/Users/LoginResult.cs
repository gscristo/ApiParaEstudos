using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Users
{
    public class LoginResult
    {
        public Guid UsersId { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

        public static implicit operator LoginResult(Core.Users.Model.Users model)
        {
            if (model == null)
                return null;

            return new LoginResult
            {
                Usuario= model.Usuario,
                Email = model.Email,
                Token = model.Token,
                UsersId = model.UsersId
            };
        }
    }
}
