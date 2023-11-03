


using Application.Behaviors;
using Asp.Versioning;
using Asp.Versioning.Routing;
using Domain.Abstractions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Data;
using System.Reflection;
using Web.Helpers;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

builder.Services.AddApiVersioning(
                    options =>
                    {
                        options.DefaultApiVersion = new ApiVersion(1, 0);
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.ReportApiVersions = true;                        
                    })
                .AddMvc();

var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

builder.Services.AddMediatR(applicationAssembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddControllers()
    .AddApplicationPart(presentationAssembly);

builder.Services.AddSwaggerGen(c =>
{
    var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

    var presentationDocumentationFilePath =
        Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);
  
    c.IncludeXmlComments(presentationDocumentationFilePath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
});




ConfigurationManager configuration = builder.Configuration;

var authenticationConfiguration = new AuthenticationConfiguration();
builder.Configuration.GetSection(nameof(AuthenticationConfiguration)).Bind("AuthenticationConfiguration", authenticationConfiguration);

builder.Services.AddDbContext<ApplicationDbContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("Application")));

builder.Services.AddAuthentication("Token").AddScheme<TokenAuthenticationOptions, CustomAuthenticationHandler>("Token", "Token Title", null);

builder.Services.AddScoped<IAuthenticationManager, JWTAuthenticationManager>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IRouteAddressRepository, RouteAddressRepository>();

builder.Services.AddScoped<IUnitOfWork>(
    factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IDbConnection>(factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedCorsOrigins",
        builder =>
        {
            builder                
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
}

app.UseCors();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

using var scope = app.Services.CreateScope();

await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

await dbContext.Database.MigrateAsync();



await app.RunAsync();
