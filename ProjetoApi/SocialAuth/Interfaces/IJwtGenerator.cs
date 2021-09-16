using System;

namespace Api.SocialAuth.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateUserAuthToken(Guid UsersId);
    }
}