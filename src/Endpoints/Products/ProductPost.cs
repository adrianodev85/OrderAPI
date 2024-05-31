using OrderAPI.Domain.Products;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Products;

public class ProductPost
{
    public static string Template => "/product";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ProductRequest prodRequest, AppDbContext context)
    {
        var categoryProd = context.Categories.FirstOrDefault(c => c.Name == prodRequest.category);

        if(categoryProd == null)
        {
            return Results.NotFound($"{prodRequest.category} is not found");
        }

        var product = new Product(prodRequest.name, prodRequest.description, prodRequest.price,
            prodRequest.hasStock, categoryProd, "Adriano Pinho", "Adriano Pinho");

        if (!product.IsValid)
        {
            return Results.ValidationProblem(product.Notifications.ConvertToProblemaDetails());
        }

        context.Products.Add(product);
        context.SaveChanges();

        return Results.Created($"/product/{product.Id}", product.Id);
    }
}
