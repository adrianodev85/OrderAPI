using Microsoft.AspNetCore.Mvc;
using OrderAPI.Infrastructure.Data;
using System.ComponentModel;

namespace OrderAPI.Endpoints.Products;

public class ProductDelete
{
    public static string Template => "/product/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, AppDbContext context)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return Results.NotFound($"{id} not found");
        }
        else
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        return Results.Ok($"{id} removed");
    }
}
