using LauriesEC.Fence;
using LauriesEC.Fences.Repositories;
using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Service.Calculator;
using LauriesEC.Service.Calculator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFencesServices, FencesServices>();
builder.Services.AddScoped<ISupplier, Supplier>();
builder.Services.AddScoped<IPriceByService,  PriceByService>();
builder.Services.AddScoped<IStateTaxRate, USATaxRate>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.UseCors("AllowAll");
app.Run();
