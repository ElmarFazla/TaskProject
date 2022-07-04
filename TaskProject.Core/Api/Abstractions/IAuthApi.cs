using System.Threading.Tasks;

namespace TaskProject.Core.Api.Abstractions
{
    public interface IAuthApi
    {
        Task<string> Login(string username, string password);
    }
}
