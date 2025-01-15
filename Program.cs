using Microsoft.EntityFrameworkCore;
using Tournaments.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map custom route for Tournament
app.MapControllerRoute(
    name: "tournamentRoute",
    pattern: "Tournament/{tourName}",
    defaults: new { controller = "Tournament", action = "Index" });

// Default route configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Touenament}/{action=Index}/{id?}");

app.Run();

