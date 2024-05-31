namespace OrderAPI.Endpoints.Products;

public record ProductRequest(string name, string description, double price, string category, bool hasStock);
