using AppService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security;
using System.Threading.Tasks;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationApiController : ControllerBase
    {
        private readonly IApplicationAppService service;

        public ApplicationApiController(IApplicationAppService service)
        {
            this.service = service;
        }

        public ApplicationTokenOutput CreateToken(ApplicationTokenData input)
        {
            return this.service.CreateToken(input);
        }

        public async Task<string> ValidateToken(string token)
        {
            return await this.service.ValidateToken(token);
        }
    }
}
