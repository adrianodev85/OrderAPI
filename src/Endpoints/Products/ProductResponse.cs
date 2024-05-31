namespace OrderAPI.Endpoints.Products;

public record ProductResponse(Guid id, string name, string description, double price, 
    string category, bool hasStock);
