using AspProMongoDb.WebApp.DataBase;
using AspProMongoDb.WebApp.Models;
using AspProMongoDb.WebApp.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddRazorPages();
services.AddScoped<IUserService, UserService>();
services.AddScoped<MongoDbContext>();
services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

services.AddSingleton<IMongoClient, MongoClient>(service =>
{
    var mongoSettings = service.GetRequiredService<MongoSettings>();
    return new MongoClient(mongoSettings.ConnectionString);
});

services.AddSingleton<MongoSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
