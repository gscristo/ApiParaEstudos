using System;

namespace Core.Users.Model
{
  public class Users
    {
        public Guid UsersId { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }

        public static implicit operator Users(DataAccess.Entities.Users model)
        {
            if (model == null)
                return null;


            return new Users
            {
                UsersId = model.UsersId,
                Usuario = model.Usuario,
                Email = model.Email,
                Senha = model.Senha
            };

        }

        public static implicit operator DataAccess.Entities.Users(Users users)
        {
            if (users == null)
                return null;


            // return new Users 
            return new DataAccess.Entities.Users
            {
                UsersId = users.UsersId,
                Usuario = users.Usuario,
                Email = users.Email,
                Senha = users.Senha
            };

        }
    }

}
