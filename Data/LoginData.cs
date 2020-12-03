using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class LoginData : ILoginData
    {
        public bool Login(string login, string senha)
        {
            return login == "admin" && senha == "admin";
        }
    }
}
