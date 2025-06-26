namespace ReferenceClass.Models;

public class ProductDto
{
    public IEnumerable<Product> Products { get; set; }
    public int TotalCount { get; set; }
    
}