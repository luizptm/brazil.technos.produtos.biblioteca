using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public interface ILoginController
    {
        bool Login(string login, string senha);
    }
}
