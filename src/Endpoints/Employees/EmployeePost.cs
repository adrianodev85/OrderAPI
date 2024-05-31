using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace OrderAPI.Endpoints.Employees;

public class EmployeePost
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = employeeRequest.email, Email = employeeRequest.email };
        var result = userManager.CreateAsync(user, employeeRequest.password).Result;

        if (!result.Succeeded)
        {
            return Results.ValidationProblem(result.Errors.ConvertToProblemaDetails());
        }

        var userClaims = new List<Claim>()
        {
            new Claim("Name", employeeRequest.name),
            new Claim("EmployeeCode", employeeRequest.employeeCode)
        };

        var resultClaim = userManager.AddClaimsAsync(user, userClaims).Result;

        if (!resultClaim.Succeeded)
        {
            return Results.BadRequest(resultClaim.Errors.ConvertToProblemaDetails());
        }
        
        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}
