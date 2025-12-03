using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CORE1.Models.TallerEF2>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie( options =>
    {
        options.ExpireTimeSpan=TimeSpan.FromMinutes(60);
        options.SlidingExpiration=true;
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
    });
builder.Services.AddSession();
builder.Services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
var app = builder.Build();

var cultureInfo = new System.Globalization.CultureInfo("es-ES");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo; 
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseStatusCodePagesWithReExecute("/Errors/NotFound");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
