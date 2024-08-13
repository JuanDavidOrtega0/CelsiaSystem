using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CelsiaProject.Services;
using CelsiaProject.Models;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        
        // Create
        _userRepository.Add(user);
        return RedirectToAction("Index", "Home");
    }
}