select us.Id as Id, uc1.ClaimValue as Name, us.Email as Email, uc2.ClaimValue as EmployeeCode
from AspNetUsers us
inner join AspNetUserClaims uc1
on us.Id = uc1.UserId and uc1.ClaimType = 'Name'
inner join AspNetUserClaims uc2
on us.Id = uc2.UserId and uc2.ClaimType = 'EmployeeCode' 
order by Name
OFFSET 1 ROWS
FETCH NEXT 4 ROWS ONLY
GO