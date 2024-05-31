using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Products;

public class ProductGetAll
{
    public static string Template => "/product";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext context)
    {
        var products = context.Products;
        var response = products.Select(p => new ProductResponse(p.Id, p.Name, p.Description,
            p.Price, p.Category.Name, p.HasStock));

        return Results.Ok(response);
    }
}
