using Microsoft.EntityFrameworkCore;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Services;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;
using TaxCalculator.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaxCalculatorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxCalculatorConnectionString")));

builder.Services.AddScoped<ICalculatedTaxRepository, CalculatedTaxRepository>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<IReferenceListService, ReferenceListService>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
