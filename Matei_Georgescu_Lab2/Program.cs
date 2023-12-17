using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Matei_Georgescu_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the DbContext for your application data
builder.Services.AddDbContext<Matei_Georgescu_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Matei_Georgescu_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Matei_Georgescu_Lab2Context' not found.")));

// Register the Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Matei_Georgescu_Lab2Context>(); // Use Matei_Georgescu_Lab2Context for identity store

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
