using System.Text.Json.Serialization;

namespace ReferenceClass.Models;

public class AuthenticationData : BaseEntity
{
    public string UserName { get; set; }

    [JsonPropertyName("password")] public string PasswordHash { get; set; }
}