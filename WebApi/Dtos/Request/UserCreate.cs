using WebApi.Models.Enums;

namespace WebApi.Dtos.Request;

public class UserCreate
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}