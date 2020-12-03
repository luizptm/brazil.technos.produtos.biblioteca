﻿using Security;
using System.Threading.Tasks;

namespace AppService
{
    public interface IApplicationAppService
    {
        ApplicationTokenOutput CreateToken(ApplicationTokenData input);

        Task<string> ValidateToken(string token);
    }
}
