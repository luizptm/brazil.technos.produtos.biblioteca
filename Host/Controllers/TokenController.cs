using AppService;
using Microsoft.AspNetCore.Mvc;
using Security;
using System;
using System.Threading.Tasks;

namespace Host.Controllers
{
    /// <summary>
    /// TokenController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenAppService service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        public TokenController(ITokenAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Cria Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public String Create(ApplicationTokenData input)
        {
            ApplicationTokenOutput applicationTokenOutput = this.service.CreateToken(input);
            if (applicationTokenOutput != null)
            {
                return applicationTokenOutput.Token;
            }
            return "ERRO!";
        }

        /// <summary>
        /// Valida Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Validate(string token)
        {
            return await this.service.ValidateToken(token);
        }
    }
}
