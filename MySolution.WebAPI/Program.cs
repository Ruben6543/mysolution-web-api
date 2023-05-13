using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MySolution.Domain.DependencyInjection;
using MySolution.Domain.Infraestructure;
using MySolution.WebAPI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterSolutionResources(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
