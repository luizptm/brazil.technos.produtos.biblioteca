using Security;
using System.Threading.Tasks;

namespace AppService
{
    public interface ITokenAppService
    {
        object CreateToken(ApplicationTokenData input);

        Task<string> ValidateToken(string token);
    }
}
