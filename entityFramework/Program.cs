using entityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Configuracion de la DB en memory
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlite<TareasContext>("Data Source=./Data/TareasDB.db; Initial Catalog=TareasDB;");  // Me falta aqui

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices]  TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsSqlite());
});

app.Run();
