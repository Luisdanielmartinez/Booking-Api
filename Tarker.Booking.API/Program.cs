using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataBaseService>(options =>
options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

builder.Services.AddScoped<IDataBaseService, DataBaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();


