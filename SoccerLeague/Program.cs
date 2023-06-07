using Microsoft.EntityFrameworkCore;
using SoccerLeague.Data;
using SoccerLeague.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SoccerLeagueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoccerLeagueContext") ?? throw new InvalidOperationException("Connection string 'SoccerLeagueContext' not found.")));

builder.Services.AddScoped<IMatchService, MatchService>();

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
