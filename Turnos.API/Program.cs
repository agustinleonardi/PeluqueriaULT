using Turnos.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.Services;
using Turnos.Infrastructure.Repositories;
using Turnos.Infrastructure.Services;
using Turnos.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Turnos.API.Validators;
using FluentValidation;
using Turnos.API.Mappers;
using Turnos.Application.Mappers;
using Turnos.Infrastructure.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddAutoMapper(
    typeof(MappingProfileAPI),
    typeof(MappingProfileApplication),
    typeof(MappingProfileInfra));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();



builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware global de manejo de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();