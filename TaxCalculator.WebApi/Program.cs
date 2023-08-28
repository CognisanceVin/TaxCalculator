using Microsoft.EntityFrameworkCore;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Services;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;
using TaxCalculator.Infrastructure.Repository;
using TaxCalculator.IoC;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaxCalculatorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxCalculatorConnectionString")));

builder.Services.AddScoped<ICalculatedTaxRepository, CalculatedTaxRepository>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<IReferenceListService, ReferenceListService>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();

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

app.Run();
