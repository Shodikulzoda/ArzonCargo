using System.Text.Json.Serialization;
using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class AuthenticationData : BaseEntity
{
    public string UserName { get; set; }
    public Role Role { get; set; }
    [JsonPropertyName("password")] public string PasswordHash { get; set; }
}