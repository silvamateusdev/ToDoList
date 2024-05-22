
using Microsoft.EntityFrameworkCore;
using Api.Infrastructure.Data;
using Api.Domain.DTOs;
using FluentValidation;
using Api.Domain.Validator;
using Api.Application.EndPoints;
using Api.Application.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.WithOrigins("*")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConnection = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<SqlContext>(options => options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)));
builder.Services.AddScoped<IValidator<TaskDto>, TaskValidator>();

builder.Services
       .RegisterServicesIOC()
       .RegisterRepositoriesIOC();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterTaskEndPoints();
app.RegisterDayEndPoints();


app.Run();