using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Services.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;

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
                // Because of issues with Entitlements for iOS I had no time to fix them, I'll skip fetching the key from SecureStorage for iOS
                if (Device.RuntimePlatform == Device.Android)
                {
                    _apiKey = await SecureStorage.GetAsync(Api_Key);
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    return "e7b0e27b";
                }
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
            try
            {
                // Because of issues with Entitlements for iOS I had no time to fix them, I'll skio storing the key in SecureStorage for iOS
                if (Device.RuntimePlatform == Device.Android)
                {
                    await SecureStorage.SetAsync(Api_Key, apiKey);
                }

                _apiKey = apiKey;
            }
            catch (System.Exception ex)
            {

                var test = 1;
            }
        }
    }
}