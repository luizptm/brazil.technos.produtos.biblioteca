using Data;

namespace Controller
{
    public class LoginController
    {
        public bool Login(string login, string senha)
        {
            LoginData data = new LoginData();
            return data.Login(login, senha);
        }
    }
}
