using AppService;
using Microsoft.AspNetCore.Mvc;
using Security;
using System.Threading.Tasks;

namespace Host.Controllers
{
    /// <summary>
    /// TokenController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        public ApplicationTokenOutput Create(ApplicationTokenData input)
        {
            return this.service.CreateToken(input);
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
