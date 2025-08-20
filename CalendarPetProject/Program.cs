using CalendarPetProject.BusinessLogic.AITextGenerative;
using CalendarPetProject.BusinessLogic.JSONParse;
using CalendarPetProject.Data;
using CalendarPetProject.Data.Constants;
using CalendarPetProject.Data.Constants.FileNames;
using CalendarPetProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
string dbConnectionStringFileName = FileNames.DbConnectionStringFileName;
string apiContainerFileName = FileNames.ApiKeyFileName;

DataBaseConnectionString dbConnectionString = JSONSerializer.GetData<DataBaseConnectionString>(dbConnectionStringFileName);
ApiKeys apiKeys = JSONSerializer.GetData<ApiKeys>(apiContainerFileName);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(dbConnectionString.DBConnectionString));

builder.Services.AddIdentity<Users, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 5;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedAccount = false;
    }
).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // or adjust naming if needed
    });
builder.Services.AddTransient<GeminiDelegatingHandler>();

builder.Services.AddHttpClient<GeminiClient>(client =>
{
    client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent");
})
.AddHttpMessageHandler<GeminiDelegatingHandler>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.Run();
