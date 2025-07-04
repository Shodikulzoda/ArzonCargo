namespace MudBlazor.Components.Service;

public class AuthService
{
    public string? Token { get; private set; }

    public void SetToken(string token)
    {
        Token = token;
    }
}