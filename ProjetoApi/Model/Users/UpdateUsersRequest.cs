using System;

namespace Api.Model
{
    public class UpdateUsersRequest
    {
        public Guid UsersId { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static implicit operator Core.Users.Model.Users(UpdateUsersRequest updateUsersRequest)
        {
            if (updateUsersRequest == null)
                return null;


            return new Core.Users.Model.Users

            {   UsersId = updateUsersRequest.UsersId,
                Usuario = updateUsersRequest.Usuario,
                Email = updateUsersRequest.Email,
                Senha = updateUsersRequest.Senha
            };

        }
    }
}
