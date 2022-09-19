using Azure.Identity;
using GotwAPI.Context;
using GotwAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
}

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.File("Logs/GoTW_.txt", rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connString = builder.Configuration.GetConnectionString("DefaultConnection");

//if (!string.IsNullOrEmpty(connString))
//    builder.Services.AddAzureAppConfiguration();

//if (string.IsNullOrEmpty(connString))
//    connString = builder.Configuration.GetConnectionString("local");

//var connString = builder.Configuration.GetConnectionString("local");
var connString = builder.Configuration.GetConnectionString("dock");

builder.Services.AddDbContext<CommanderContext>(options =>
{
    options.UseSqlServer(connString);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddScoped<ICommanderRepository, CommanderRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GotwAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapGet("api/Commanders/{skill?}", async ([FromRoute] string skill, ICommanderRepository rep, HttpRequest http) =>
{
    Log.Information("User: {Name}!", Environment.UserName);
    Log.Information("MachineName: {MachineName}!", Environment.MachineName);
    Log.Information($"start executing api/Commanders/{skill}...)");
    Uri imgUri = new(string.Concat(http.Scheme.ToString(), "://", http.Host.ToString()));
    Log.Information($"end executing api/Commanders/{skill}...)");
    Log.Information("ExitCode: {ExitCode}!", Environment.ExitCode);
    Log.Information("StackTrace: {StackTrace}!", Environment.StackTrace);
    Log.CloseAndFlush();
    return await rep.GetCommanderSkill(imgUri, skill);
})
.WithName("GetCommanderSkill");

app.Run();