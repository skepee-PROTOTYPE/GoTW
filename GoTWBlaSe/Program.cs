using GoTWBlaSe;
//using GoTWBlaSe.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddScoped<GoTWHttp>();
builder.Services.AddHttpClient();

if (builder.Environment.IsDevelopment())
    Helper.apiAddress = "https://localhost:52016/";
else
    Helper.apiAddress = "https://gotwapi.azurewebsites.net/";

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });
//builder.Services.AddHttpClient<GoTWHttp>("GoTWApi", client => client.BaseAddress = new Uri(apiAddress));

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
