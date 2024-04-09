using Homies.Data;
using Homies.Services;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HomiesDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
	options.SignIn.RequireConfirmedAccount = builder.Configuration
						.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
	options.Password.RequireDigit = builder.Configuration
		.GetValue<bool>("Identity:Password:RequireDigit");
	options.Password.RequireNonAlphanumeric = builder.Configuration
		.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
	options.Password.RequireUppercase = builder.Configuration
		.GetValue<bool>("Identity:Password:RequireUppercase");

	//options.Password.RequireLowercase = builder.Configuration
	//    .GetValue<bool>("Identity:Password:RequireLowercase");
	//options.Password.RequiredLength = builder.Configuration
	//    .GetValue<int>("Identity:Password:RequiredLength");
	//options.Lockout.MaxFailedAccessAttempts = builder.Configuration
	//    .GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");

	//options.SignIn.RequireConfirmedAccount = false;
	//options.Password.RequireDigit = false;
	//options.Password.RequireNonAlphanumeric = false;
	//options.Password.RequireUppercase = false;

})
    .AddEntityFrameworkStores<HomiesDbContext>();
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<IEventParticipantService, EventParticipantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
