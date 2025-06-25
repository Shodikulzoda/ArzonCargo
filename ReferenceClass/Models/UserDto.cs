namespace ReferenceClass.Models;

public class UserDto
{
    public IEnumerable<User> Users { get; set; }
    public int TotalCount { get; set; }
    
}