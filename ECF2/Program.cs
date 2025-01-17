using ECF2.Data;
using ECF2.Helpers;
using ECF2.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(/*options =>
{
    // Format route value in kebab case
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                 new SlugifyParameterTransformer()));
}*/
);


//string? connectionString = builder.Configuration.GetConnectionString("SqlServerDocker");
string? connectionString = builder.Configuration.GetConnectionString("SqlServerLocalDb");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Unable to connect to database due to missing connection string.")));

builder.Services.Configure<ECF2.Models.MongoDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddSingleton<StatisticService>();

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
