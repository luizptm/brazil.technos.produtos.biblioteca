using AppService;
using Microsoft.AspNetCore.Authorization;
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
        //[AllowAnonymous]
        //[HttpPost]
        //public object Post(ApplicationTokenData input)
        //{
        //    DateTime dataCriacao = DateTime.Now;
        //    var token = TokenConfigurer.Create();

        //    return new
        //    {
        //        authenticated = true,
        //        created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
        //        expiration = TokenConfigurer.dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
        //        accessToken = token,
        //        message = "OK"
        //    };
        //}

        /// <summary>
        /// Cria Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, ActionName("Create")]
        public object Create(ApplicationTokenData input)
        {
            var applicationTokenOutput = this.service.CreateToken(input);
            if (applicationTokenOutput != null)
            {
                return applicationTokenOutput;
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
