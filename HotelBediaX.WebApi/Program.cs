using HotelBediaX.WebApi.DI;
using HotelBediaX.Infrastructure.Persistence;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProjectServices(builder.Configuration);
builder.Services.AddUseCases();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Seed in-memory database with sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Destinations.Any())
    {
        var now = DateTime.UtcNow;
        var destinations = Enumerable.Range(1, 30).Select(i => new Destination
        {
            Name = $"Destination {i}",
            CountryCode = $"C{i:D2}",
            Description = $"Description for destination {i}",
            Type = DestinationType.Other,
            CreatedDate = now,
            UpdatedDate = now
        });
        context.Destinations.AddRange(destinations);
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularClient");

app.UseAuthorization();
app.MapControllers();


app.Run();

