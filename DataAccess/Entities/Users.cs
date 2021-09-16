using System;

namespace DataAccess.Entities
{
    public class Users
    {
        public Guid UsersId { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
