using CalendarPetProject.CalendarDBContext;
using CalendarPetProject.CalendarDBContext.DataBaseOperationService;
using CalendarPetProject.CalendarDBContext.Tables;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-M2458CE\\SQLEXPRESS;Initial Catalog=CalendarDb;Integrated Security=True;Trust Server Certificate=True"));

var app = builder.Build();

// Add test user data
UserData userData = new("Roman", "Nahirnyi", "234", "123", DateTime.Now);
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    var service = new DataBaseOperationService(dbContext);
    service.UploadInformation(app, userData);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
