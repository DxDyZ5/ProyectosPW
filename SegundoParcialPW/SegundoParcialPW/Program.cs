using Microsoft.EntityFrameworkCore;
using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;
using SegundoParcialPW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<IntercambioPoliciaContext>(op => op.UseSqlServer(conn));

builder.Services.AddScoped<Iregistrar, ServiceIngresar>();
builder.Services.AddScoped<IgetAll, GetAllService>();
builder.Services.AddScoped<Ilistado, ListadoService>();
builder.Services.AddScoped<IConsultaPersona, ConsultaPersonaService>();

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
