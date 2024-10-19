using Domain;
using Logic;
using Logic.DataAccess;
using Logic.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<IRepository<Movie>, MemoryDB>();
//builder.Services.AddSingleton<IRepository<User>, MemoryDB>();
builder.Services.AddScoped<IRepository<Movie>, AppDB>();
builder.Services.AddScoped<IRepository<User>, AppDB>();
builder.Services.AddScoped<MovieLogic>();
builder.Services.AddScoped<UserLogic>();
builder.Services.AddScoped<SessionLogic>();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        providerOptions => providerOptions.EnableRetryOnFailure())
);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
