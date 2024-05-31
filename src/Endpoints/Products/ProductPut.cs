using Microsoft.AspNetCore.Mvc;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Products;

public class ProductPut
{
    public static string Template = "/product/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ProductRequest prodRequest, 
        AppDbContext context)
    {
        var categoryProd = context.Categories.FirstOrDefault(c => c.Name == prodRequest.category);

        if (categoryProd == null)
        {
            return Results.NotFound($"{prodRequest.category} category not found");
        }

        var product = context.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return Results.NotFound($"{id} not found");
        }
        else
        {
            product.EditInfo(prodRequest.name, prodRequest.description, prodRequest.price,
                prodRequest.hasStock, categoryProd, "Adriano Pinho", "Adriano Pinho");

            if(!product.IsValid)
            {
                return Results.ValidationProblem(product.Notifications.ConvertToProblemaDetails());
            }

            context.SaveChanges();
        }

        return Results.Ok($"{id} updated");

    }
}
