using System;

namespace Api.Model
{
    public class CreateUsersRequest
    {
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static implicit operator Core.Users.Model.Users(CreateUsersRequest createUsersRequest)
        {
            if (createUsersRequest == null)
                return null;
            
            
                return new Core.Users.Model.Users
                {
                    Usuario = createUsersRequest.Usuario,
                    Email = createUsersRequest.Email,
                    Senha = createUsersRequest.Senha
                };
            
        }
    }
}
