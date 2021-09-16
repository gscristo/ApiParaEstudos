using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItsAliveController : ControllerBase
    {
        IConfiguration _configuration;

        public ItsAliveController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public async Task<Result> Get()
        {
            var content = new
            {
                ServerCulture = CultureInfo.CurrentCulture.DisplayName,
                ApplicationStatus = $"Application is running. [ProjetoApi] - Environment : {_configuration["ENV_NAME"]}",
                Message = "PRIMEIRA API DO ZERO NO AR"
            };
            return Result.Create(content, System.Net.HttpStatusCode.OK, "Requisição executada com sucesso");
        }

    }
}
