using Context;
using Context.Repositories;
using Context.Repositories.Interfaces;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(
    cfg => 
    {
        cfg.AddProfile<DomainProfile>();
    });

builder.Services.AddDbContext<ApiContext>
    (options => options.UseInMemoryDatabase(databaseName: "ExampleDb"));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddMvc (
    options => 
    {
        options.UseGlobalRoutePrefix (new RouteAttribute ($"api/"));
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
