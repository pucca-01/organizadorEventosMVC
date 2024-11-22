using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (aj�stalo seg�n lo necesites)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// Configura la autenticaci�n con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Ruta de login
        options.LogoutPath = "/Account/Logout"; // Ruta de logout
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Tiempo de expiraci�n de la cookie
    });

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (aj�stalo seg�n lo necesites)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Usa CORS
app.UseCors();

app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Usa el middleware de autenticaci�n y autorizaci�n
app.UseAuthentication();  // A�adido para que se gestione la autenticaci�n
app.UseAuthorization();   // Se asegura de que la autorizaci�n sea aplicada

app.UseRouting();

// Mapea las rutas del controlador (asegurando que funcione correctamente el MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Usa CORS
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
