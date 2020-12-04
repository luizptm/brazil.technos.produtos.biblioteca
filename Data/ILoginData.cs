using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ILoginData
    {
        bool Login(string login, string senha);
    }
}
