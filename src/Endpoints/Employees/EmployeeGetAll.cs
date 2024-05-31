using Dapper;
using Microsoft.Data.SqlClient;

namespace OrderAPI.Endpoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employee";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(int? page, int? rows, IConfiguration config)
        {
            if (page == null || rows == null)
            {
                page = 1;
                rows = 3;
            }
            if (page <= 0 || rows <= 0) {
                page = 1;
                rows = 3;
            }

            var db = new SqlConnection(config["ConnectionStrings:OrderDB"]);
            var query = @"select us.Id as Id, uc1.ClaimValue as Name, us.Email as Email, uc2.ClaimValue as EmployeeCode
                    from AspNetUsers us
                    inner join AspNetUserClaims uc1
                    on us.Id = uc1.UserId and uc1.ClaimType = 'Name'
                    inner join AspNetUserClaims uc2
                    on us.Id = uc2.UserId and uc2.ClaimType = 'EmployeeCode' 
                    order by Name
                    OFFSET (@page - 1) * @rows ROWS
                    FETCH NEXT @rows ROWS ONLY";
            var employees = db.Query<EmployeeResponse>(
                    query,
                    new { page, rows}
                );
             
            return Results.Ok( employees );
        }
    }
}
