using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Minimal_API_futball;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(policy =>
   {
       policy.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
   });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/times", async (AppDbContext db) => 
{
    return await db.Times.ToListAsync();
});  
app.MapGet("/times/{id}", async (AppDbContext db,int id) => 
{
    var time = await db.Times.FindAsync(id);
    return time is null ? Results.NotFound() : Results.Ok(time);
});
app.MapPost("/times", async (AppDbContext db, Time time) =>
{   
    db.Times.Add(time);
    await db.SaveChangesAsync();
    return Results.Created($"O time {time.Nome} foi inserido com sucesso",time);
});
app.MapPut("/times/{id}", async (AppDbContext db, int id,Time atualizado) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null)
    {
        return Results.NotFound("Time nao encontrado");
    }
    time.Nome = atualizado.Nome; 
    time.Id = id;
    time.Cidade = atualizado.Cidade;
    time.Titulos = atualizado.Titulos;   
   
    await db.SaveChangesAsync();
    return Results.Ok(time);
});


app.MapDelete("/times/{id}",
    async (AppDbContext db,
        int id) =>
    {
        var time = await db.Times.FindAsync(id);
        if (time is null)
        {
            return Results.NotFound();
        }

        db.Times.Remove(time);
        db.SaveChanges();
        return Results.NoContent();
    });
app.Run();

