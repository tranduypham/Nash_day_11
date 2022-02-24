using EF_Core_2.Models;
using EF_Core_2.Repository;
using EF_Core_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer("Server=DESKTOP-C00IDIB;Initial Catalog=ProductEFCore2;Integrated Security=True")
);
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
