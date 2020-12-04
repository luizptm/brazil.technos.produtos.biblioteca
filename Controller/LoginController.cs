using Data;

namespace Controller
{
    public class LoginController
    {
        private readonly ILoginData data;

        public LoginController(ILoginData data)
        {
            this.data = data;
        }

        public bool Login(string login, string senha)
        {
            return data.Login(login, senha);
        }
    }
}
