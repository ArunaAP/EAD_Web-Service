using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TicketBooking.Models;
using TicketBooking.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for Employee
builder.Services.Configure<EmployeeStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(EmployeeStoreDatabaseSettings)));

builder.Services.AddSingleton<IEmployeeStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EmployeeStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("EmployeeStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Add services to the container for Traveller
builder.Services.Configure<TravellerStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TravellerStoreDatabaseSettings)));

builder.Services.AddSingleton<ITravellerStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TravellerStoreDatabaseSettings>>().Value);

builder.Services.AddScoped<ITravelerService, TravellerService>(); // Assuming you have a TravellerService

builder.Services.AddScoped<ITravelerService, TravellerService>();


// Add services to the container for TicketBooking
builder.Services.Configure<TicketBookingStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TicketBookingStoreDatabaseSettings)));

builder.Services.AddSingleton<ITicketBookingStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TicketBookingStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("TicketBookingStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ITicketBookingService, TicketBookingService>();

// Add services to the container for Train
builder.Services.Configure<TrainStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TrainStoreDatabaseSettings)));

builder.Services.AddSingleton<ITrainStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TrainStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("TrainStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ITrainService, TrainService>();



builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
