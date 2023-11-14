


using Application.Behaviors;
using Asp.Versioning;
using Domain.Abstractions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.Services;
using Presentation.TableEntities;
using System.Data;
using WebApi.Configurations;
using WebApi.CustomHandlers;
using WebApi.Helpers;
using WebApi.Middleware;

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

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bubblewell.WebApi", Version = "v1" });
});

ConfigurationManager configuration = builder.Configuration;

var authenticationConfiguration = new AuthenticationConfiguration();
builder.Configuration.GetSection(nameof(AuthenticationConfiguration)).Bind("AuthenticationConfiguration", authenticationConfiguration);

builder.Services.AddDbContext<ApplicationDbContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("Application")));
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddAuthentication("Token").AddScheme<TokenAuthenticationOptions, CustomAuthenticationHandler>("Token", "Token Title", null);

builder.Services.AddScoped<IAuthenticationManager, JWTAuthenticationManager>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICompanyPublisherRepository, CompanyPublisherRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyRouteRepository, CompanyRouteRepository>();
builder.Services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IRouteAddressPublisherRepository, RouteAddressPublisherRepository>();
builder.Services.AddScoped<IRouteAddressRepository, RouteAddressRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRouteRepository, UserRouteRepository>();
builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();

//builder.Services.AddSingleton<IRepository<AddressSync>>(new InMemoryRepository<AddressSync>());
builder.Services.AddScoped<IRepository<AddressSync>, AddressRespo>();


//builder.Services.AddSingleton<IAddressSyncService, InMemoryAddressSyncService>();

builder.Services.AddDatasyncControllers();


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
//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
//}
//Seed database with root user



app.UseCors();

app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseMiddleware<AuthenticationMiddleware>();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseItToSeedSqlServer();

//using var scope = app.Services.CreateScope();

//await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//await dbContext.Database.MigrateAsync();



await app.RunAsync();
