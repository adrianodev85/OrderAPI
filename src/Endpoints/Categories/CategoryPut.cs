using Microsoft.AspNetCore.Mvc;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/category/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoryRequest request, AppDbContext context)
    {
        var category = context.Categories.FirstOrDefault(c => c.Id == id);
        if(category == null)
        {
            return Results.NotFound();
        }
        else
        {
            category.EditInfo(request.name, request.active);

            if(!category.IsValid)
            {
                return Results.ValidationProblem(category.Notifications.ConvertToProblemaDetails());
            }

            context.SaveChanges();
        }

        return Results.Ok($"{id} updated");
    }
}
