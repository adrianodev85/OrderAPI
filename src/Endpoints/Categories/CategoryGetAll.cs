using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/category";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext context)
    {
        var categories = context.Categories;
        var response = categories.Select(c => new CategoryResponse(c.Id,c.Name,c.Active));

        return Results.Ok(response);
    }
}
