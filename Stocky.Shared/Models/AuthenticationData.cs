using System.Text.Json.Serialization;
using Stocky.Shared.Models.Enums;

namespace Stocky.Shared.Models;

public class AuthenticationData : BaseEntity
{
    public string? UserName { get; set; }
    public Role Role { get; set; }
    [JsonPropertyName("password")] public string? PasswordHash { get; set; }
}