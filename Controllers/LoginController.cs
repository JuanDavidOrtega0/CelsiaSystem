using CelsiaProject.Utils;
using CelsiaProject.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using CelsiaProject.Models.DTOs;
using CelsiaProject.Services;
using Microsoft.EntityFrameworkCore;

public class LoginController : Controller
{
    private readonly Bcrypt _bcrypt;
    private readonly IJwtRepository _jwtRepository;
    private readonly CelsiaContext _context;

    public LoginController(Bcrypt bcrypt, IJwtRepository jwtRepository, CelsiaContext context)
    {
        _bcrypt = bcrypt;
        _jwtRepository = jwtRepository;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Please fill all fields.";
            return View();
        }

        var User = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (email == User.Email && password == User.Password)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Email),
                    new Claim(ClaimTypes.Role, "User")
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            });
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Credenciales inválidas";

        if (User == null)
        {
            ViewBag.Error = "The email or password are invalid.";
            return View();
        }

        else
        {
            if (_bcrypt.VerifyPassword(password, User.Password))
            {
                var UserDto = new UserDto
                {
                    Email = email,
                    Password = password
                };
                var Token = _jwtRepository.GenerateToken(UserDto);

                Response.Headers.Add("Authorization", "Bearer " + Token);
                Response.Cookies.Append("jwt", Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View();
        }

        
    }

    public async Task<IActionResult> Logout()
    {
        //clear cookies
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Response.Cookies.Delete("jwt");

        return RedirectToAction("Index", "Login");
    }
}