using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MudBlazor.Components.Service;

public class AuthService : IDisposable
{
    private readonly IJSRuntime jsRuntime;
    private const string TokenKey = "authToken";

    public string Token { get; private set; } = "";
    public string? Username { get; private set; }
    public int EmployeeId { get; private set; }
    public string? Role { get; private set; }

    public event Action? OnChange;

    public bool IsAdmin => string.Equals(Role, "admin", StringComparison.OrdinalIgnoreCase);
    public bool IsAdder => string.Equals(Role, "adder", StringComparison.OrdinalIgnoreCase);
    public bool IsCashier => string.Equals(Role, "cashier", StringComparison.OrdinalIgnoreCase);

    public AuthService(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task SetTokenAsync(string token)
    {
        Token = token;
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
        ParseRoleFromToken(token);
        ParseUsernameFromToken(token);
        ParseEmployeeIdFromToken(token);    
        NotifyStateChanged();
    }

    public async Task LoadTokenAsync()
    {
        var token = await jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
        Token = token ?? "";

        if (!string.IsNullOrEmpty(Token))
        {
            ParseRoleFromToken(Token);
            ParseUsernameFromToken(Token);
            ParseEmployeeIdFromToken(token);
        }
        else
        {
            Role = null;
        }

        NotifyStateChanged();
    }

    public async Task ClearTokenAsync()
    {
        Token = "";
        await jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        Role = null;
        NotifyStateChanged();
    }

    public async Task<string?> GetUserRoleAsync()
    {
        if (string.IsNullOrEmpty(Token))
            return null;

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(Token);

        foreach (var claim in jwt.Claims)
        {
            Console.WriteLine($"Claim type: {claim.Type}, value: {claim.Value}");
        }

        var roleClaim =
            jwt.Claims.FirstOrDefault(c => c.Type == "role" || c.Type == ClaimTypes.Role || c.Type == "roles");
        return roleClaim?.Value;
    }


    private void ParseRoleFromToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Role = jwtToken.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.Role || c.Type == "role")?.Value;
        }
        catch
        {
            Role = null;
        }
    }

    public void Dispose()
    {
        OnChange = null;
    }

    private void ParseUsernameFromToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var usernameClaim = jwtToken.Claims.FirstOrDefault(c =>
                c.Type == "name" || c.Type == "unique_name" || c.Type == "sub" || c.Type == ClaimTypes.Name);

            Username = usernameClaim?.Value;

            Console.WriteLine($"Parsed Username from token: {Username}");
        }
        catch
        {
            Username = null;
        }
    }

    private void ParseEmployeeIdFromToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var idClaim = jwtToken.Claims.FirstOrDefault(c =>
                c.Type == "id" || c.Type == ClaimTypes.NameIdentifier);

            EmployeeId = Convert.ToInt32(idClaim?.Value);
            Console.WriteLine($"Parsed EmployeeId: {EmployeeId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing EmployeeId from token: {ex.Message}");
            EmployeeId = 0;
        }
    }
}