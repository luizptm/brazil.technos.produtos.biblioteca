using Controller;
using Data;
using Newtonsoft.Json;
using Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AppService
{
    public class TokenAppService : ITokenAppService
    {
        private readonly IApplicationManager applicationManager;
        LoginController loginController;

        public TokenAppService(IApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
            LoginData data = new LoginData();
            this.loginController = new LoginController(data);
        }

        public object CreateToken(ApplicationTokenData input)
        {
            if (loginController.Login(input.Username, input.Senha))
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(input.Username, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, input.Username)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                var token = TokenConfigurer.Create(identity);
                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = TokenConfigurer.dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
                //return output;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> ValidateToken(string token)
        {
            return await Task.Run(() => applicationManager.ValidateToken(token));
        }
    }
}
