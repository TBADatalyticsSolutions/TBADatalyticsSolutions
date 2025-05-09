using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TBADatalyticsSolutions.Data;
using TBADatalyticsSolutions.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configure MySQL database context using Pomelo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// 🔐 Configure Identity for user authentication
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

// 👨‍💻 Add MVC and Razor Pages support
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPasswordHasher<UserAccount>, PasswordHasher<UserAccount>>();
builder.Services.AddRazorPages();

var app = builder.Build();

// ⚙️ Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // Serve static content from wwwroot
app.UseRouting();          // Enable routing

app.UseAuthentication();   // Enable Identity login
app.UseAuthorization();    // Enable access control

// 📌 Set default route to Analytics dashboard
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 🧾 Map Razor Pages (for Identity UI like Login/Register)
app.MapRazorPages();

app.Run();
