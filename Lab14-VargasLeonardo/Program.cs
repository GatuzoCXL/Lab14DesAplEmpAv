using Lab14_VargasLeonardo.Data;
using Lab14_VargasLeonardo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Lab14Database"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", async (AppDbContext db) => 
{
    return await db.Products.ToListAsync();
})
.WithName("GetProducts");

app.MapPost("/api/products", async (AppDbContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Ok(product);
})
.WithName("CreateProduct");

app.Run();