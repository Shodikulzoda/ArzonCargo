using Microsoft.JSInterop;

namespace MudBlazor.Components.Service
{
    public class AuthService
    {
        private const string TokenKey = "authToken";
        private readonly IJSRuntime _jsRuntime;

        public string Token { get; private set; } = "";

        public AuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public void SetToken(string token)
        {
            Token = token;
            _ = _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
        }

        public async Task LoadTokenAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
            Token = token ?? "";
        }

        public void ClearToken()
        {
            Token = "";
            _ = _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        }
    }
}