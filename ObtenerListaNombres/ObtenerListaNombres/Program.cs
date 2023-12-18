using Microsoft.EntityFrameworkCore;
using ObtenerListaNombres.Interfaces;
using ObtenerListaNombres.Models;
using ObtenerListaNombres.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<PersonajesSERIEPracticaContext>(op => op.UseSqlServer(conn));
builder.Services.AddScoped<Inombre, NombreServices>();
builder.Services.AddScoped<Iusuario, UsuarioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( r =>   r.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

