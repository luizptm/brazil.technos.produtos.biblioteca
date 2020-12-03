using Newtonsoft.Json;
using Security;
using System.Threading.Tasks;

namespace AppService
{
    public class ApplicationAppService : IApplicationAppService
    {
        private readonly IApplicationManager applicationManager;

        public ApplicationAppService(IApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }

        public ApplicationTokenOutput CreateToken(ApplicationTokenData input)
        {
            var app = new Application();
            if (app == null)
            {
                throw new UserFriendlyException(404, "ApplicationDoesNotExists");
            }

            var output = new ApplicationTokenOutput()
            {
                Token = applicationManager.CreateToken(app.Name, app.SecretWord, input.Username,
                    JsonConvert.SerializeObject(input)),
            };
            return output;
        }

        public async Task<string> ValidateToken(string token)
        {
            return await Task.Run(() => applicationManager.ValidateToken(token));
        }
    }
}
