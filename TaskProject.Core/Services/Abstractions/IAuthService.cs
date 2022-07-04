using System.Threading.Tasks;

namespace TaskProject.Core.Services.Abstractions
{
    public interface IAuthService
    {
        Task Login(string username, string password);

        Task<string> GetApiKey();
    }
}
