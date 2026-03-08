using LibraryWebApp.Data;
using LibraryWebApp.Repositories;
using LibraryWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>(opt => 
    opt.UseInMemoryDatabase("LibraryDb"));
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<BookService>();

// Pour servir les fichiers HTML depuis wwwroot
builder.Services.AddSingleton<IHostEnvironment>(builder.Environment);

var app = builder.Build();

app.UseDefaultFiles();   // sert index.html automatiquement
app.UseStaticFiles();    // sert les fichiers du dossier wwwroot
app.MapControllers();

app.Run();