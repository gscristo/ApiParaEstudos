using Api.Model;
using Api.Model.Users;
using Core.Infrastructure.Exceptions;
using Core.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogin _login;

        public AuthController(ILogin login)
        {
            _login = login;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsersRequest data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (data == null)
                {
                    return BadRequest();
                }

                LoginResult userLogin = await _login.Execute(data);

                return Ok(Result.Create(userLogin, HttpStatusCode.OK, "Operação executada com sucesso!"));

            }
            catch (ApiDomainException domainException)
            {
                return UnprocessableEntity(Result.Create(domainException.Errors, HttpStatusCode.UnprocessableEntity, "Erro ao executar a operação"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
