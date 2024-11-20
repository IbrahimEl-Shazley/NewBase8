using Microsoft.AspNetCore.Identity;
using NewBase.Context.Seeds;
using NewBase.Context;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Models;
using NewBase.Helpers;


var builder = WebApplication.CreateBuilder(args);
Hosting.Environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MsSqlConnectionString");
builder.Services.AddDbContextServices(builder.Configuration);

builder.Services.AddScopedServices();
builder.Services.AddTransientServices();

builder.Services.addfluentvalidation();
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

//identity

builder.Services.AddDefaultIdentityServices();

builder.Services.AddCorsServices();
builder.Services.AddHttpContextAccessor();
builder.Services.addAutoMapper();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationDbUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
    await ContextSeed.Seed(userManager, roleManager, applicationDbContext);
}


// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
app.UseExceptionHandler("/error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("NewBase");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewBase.Api v1"));

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.MapControllers();

app.Run();