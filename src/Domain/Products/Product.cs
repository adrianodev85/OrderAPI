namespace OrderAPI.Domain.Products;

public class Product : Entity
{
    public string? Description { get; set; }
    public double Price { get; set; }
    public bool HasStock { get; set; }
    public Category Category { get; set; }

}
