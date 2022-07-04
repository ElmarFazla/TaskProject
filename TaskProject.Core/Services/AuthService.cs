using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Services.Abstractions;
using Xamarin.Essentials;

namespace TaskProject.Core.Services
{
    public class AuthService : IAuthService
    {
        private const string Api_Key = "api_key";
        private string _apiKey;

        private readonly IAuthApi _authApi;

        public AuthService(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public async Task<string> GetApiKey()
        {
            if (_apiKey == null)
            {
                _apiKey = await SecureStorage.GetAsync(Api_Key);
            }

            return _apiKey;
        }

        public async Task Login(string username, string password)
        {
            var result = await _authApi.Login(username, password);
            await SetApiKey(result);
        }

        private async Task SetApiKey(string apiKey)
        {
            await SecureStorage.SetAsync(Api_Key, apiKey);
            _apiKey = apiKey;
        }
    }
}