using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.JSInterop;

namespace MudBlazor.Components.Service
{
    public class AuthService(IJSRuntime jsRuntime)
    {
        private const string TokenKey = "authToken";
        public string Token { get; private set; } = "";
        public string? Role { get; private set; }

        public void SetToken(string token)
        {
            Token = token;
            _ = jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);

            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            // Standard claim type for role is "role" or ClaimTypes.Role
            Role = jwtToken.Claims.FirstOrDefault(c =>
                c.Type is ClaimTypes.Role or "role")?.Value;
        }

        public async Task LoadTokenAsync()
        {
            var token = await jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
            Token = token;
        }

        public void ClearToken()
        {
            Token = "";
            _ = jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        }

        public bool IsAdmin => Role == "Admin";
        public bool IsAdder => Role == "Adder";
    }
}