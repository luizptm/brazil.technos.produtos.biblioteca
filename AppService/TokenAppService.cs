using Controller;
using Data;
using Newtonsoft.Json;
using Security;
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

        public ApplicationTokenOutput CreateToken(ApplicationTokenData input)
        {
            if (loginController.Login(input.Username, input.Senha))
            {
                var application = this.applicationManager.CreateApplication();
                var output = new ApplicationTokenOutput()
                {
                    Token = applicationManager.CreateToken(application.Name, application.SecretWord, input.Username,
                    JsonConvert.SerializeObject(input)),
                };
                return output;
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
