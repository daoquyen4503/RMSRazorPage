using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage;
using RMSRazorPage.Data;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorPages();  // Add Razor Pages services

// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

// Register Identity services (ensure ApplicationUser is correctly set up)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add other services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles and users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await InitialSeedData.SeedRolesAndUsers(services);
}

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages routes
app.MapRazorPages();

app.Run();
