using Microsoft.AspNetCore.Mvc;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/category/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, AppDbContext context)
    {
        var category = context.Categories.FirstOrDefault(c => c.Id == id);

        if(category == null)
        {
            return Results.NotFound($"{id} not found");
        }
        else
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
        return Results.Ok($"{id} removed");
    }
}
