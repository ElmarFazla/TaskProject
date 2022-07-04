using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;

namespace TaskProject.Core.Api
{
    public class AuthApi : IAuthApi
    {
        private const string ApiKey = "e7b0e27b";

        public Task<string> Login(string username, string password)
        {
            // This method simulates an Login API method.
            // But we return just an API key required for the Public api to work.
            // In a real app we would retrive an token and use it to access the API
            return Task.FromResult(ApiKey);
        }
    }
}