using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{
    public interface IApplicationManager
    {
        Application CreateApplication();

        string CreateToken(string application, string secretword, string username);

        string CreateToken(string application, string secretword, string username, string data);

        string ValidateToken(string token);

        string ValidateToken(string token, string secretword, int secondstoexpire);
    }
}
