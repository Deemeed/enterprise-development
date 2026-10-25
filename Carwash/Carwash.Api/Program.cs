using Carwash.Application.Services;
using Carwash.Application.Contracts;
using Carwash.Domain;
using Carwash.Domain.Entities;
using Carwash.Infrastructure.InMemory;
using Carwash.Application.Contracts.Clients;
using Carwash.Application.Contracts.Cars;
using Carwash.Application.Contracts.Services;
using Carwash.Application.Contracts.Orders;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository<Client, int>, ClientInMemoryRepository>();
builder.Services.AddSingleton<IRepository<Car, int>, CarInMemoryRepository>();
builder.Services.AddSingleton<IRepository<Service, int>, ServiceInMemoryRepository>();
builder.Services.AddSingleton<IRepository<Order, int>, OrderInMemoryRepository>();

builder.Services.AddScoped<IApplicationService<ClientDto, ClientCreateUpdateDto, int>, ClientService>();
builder.Services.AddScoped<IApplicationService<CarDto, CarCreateUpdateDto, int>, CarService>();
builder.Services.AddScoped<IApplicationService<ServiceDto, ServiceCreateUpdateDto, int>, ServiceService>();
builder.Services.AddScoped<IApplicationService<OrderDto, OrderCreateUpdateDto, int>, OrderService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
