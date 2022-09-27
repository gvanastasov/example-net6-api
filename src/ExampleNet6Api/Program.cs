//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Reflection;

using ExampleNet6Api.Context;
using ExampleNet6ApiDomain;
using ExampleNet6ApiExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using static ExampleNet6ApiInfrastructure.ApiMeta.Documentation;

[assembly:AssemblyVersion("1.0.0")]

/// <summary>
/// Main application entry point.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddControllers()
            .AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter());

                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(
            config =>
                config
                    .SwaggerDoc(v1, new OpenApiInfo { Title = "Example API - V1", Version = v1 }));

        builder.Services.AddAutoMapper(
            config => config.AddProfile<DomainProfile>());

        builder.Services.AddDbContext<DataContext>(
            options => options.UseInMemoryDatabase(databaseName: "ExampleDb"));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddMvc(
            options =>
                options
                    .UseGlobalRoutePrefix(new RouteAttribute($"api/")));

        builder.Services.AddApiVersioning(
            options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}