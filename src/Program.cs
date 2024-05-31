using Microsoft.AspNetCore.Identity;
using OrderAPI.Endpoints.Categories;
using OrderAPI.Endpoints.Employees;
using OrderAPI.Endpoints.Products;
using OrderAPI.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionStrings:OrderDB"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template,CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
app.MapMethods(CategoryDelete.Template, CategoryDelete.Methods, CategoryDelete.Handle);
app.MapMethods(EmployeePost.Template, EmployeePost.Methods, EmployeePost.Handle);
app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Methods, ProductPut.Handle);
app.MapMethods(ProductDelete.Template, ProductDelete.Methods, ProductDelete.Handle);

app.Run();

