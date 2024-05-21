using OrderAPI.Domain.Products;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/category";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest request, AppDbContext context)
    {
        var category = new Category(request.name, "Adriano Pinho", "Adriano Pinho");

        if(!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemaDetails());
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/category/{category.Id}", category.Id);
    }
}
