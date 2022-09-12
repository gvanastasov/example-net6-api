using Context;
using Context.Repositories;
using Context.Repositories.Interfaces;
using Domain;
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
    (o => o.UseInMemoryDatabase(databaseName: "ExampleDb"));

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
