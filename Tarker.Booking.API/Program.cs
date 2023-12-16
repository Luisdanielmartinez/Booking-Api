using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataBaseService>(options =>
options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

builder.Services.AddScoped<IDataBaseService, DataBaseService>();

var app = builder.Build();


app.MapPost("/createTest", async (IDataBaseService _databaseService) =>
{
    var entity = new Tarker.Booking.Domain.Entities.User.UserEntity
    {
        FirstName = "Ejemplo",
        LastName = "EEE",
        UserName = "SDFSD",
        Password = "SDFSD"
    };

    await _databaseService.User.AddAsync(entity);
    await _databaseService.SaveAsync();

    return "create Ok";
});
// Configure the HTTP request pipeline.

app.Run();


