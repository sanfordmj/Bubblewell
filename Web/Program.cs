


using Application.Behaviors;
using Domain.Abstractions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Reflection;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);


var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

builder.Services.AddControllers()
    .AddApplicationPart(presentationAssembly);

var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

builder.Services.AddMediatR(applicationAssembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddSwaggerGen(c =>
{
    var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

    var presentationDocumentationFilePath =
        Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

    c.IncludeXmlComments(presentationDocumentationFilePath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
});

var config = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.json")
           .Build();

builder.Services.AddDbContext<ApplicationDbContext>(builder =>
            builder.UseNpgsql(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRouteRepository, RouteRepository>();

builder.Services.AddScoped<IUnitOfWork>(
    factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IDbConnection>(
    factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
