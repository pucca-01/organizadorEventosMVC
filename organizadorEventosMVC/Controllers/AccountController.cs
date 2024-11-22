using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace OrganizadoreventosMVC.Controllers
{
    public class AccountController : Controller
    {
        // Acción de login (GET)
        public IActionResult Login()
        {
            return View();
        }

        // Acción de login (POST)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ValidUser(username, password))  // Aquí verificas al usuario
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        // Acción de logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private bool ValidUser(string username, string password)
        {
            // Implementa la validación del usuario con sus credenciales
            return username == "admin" && password == "password"; // Ejemplo simple
        }
    }
}
