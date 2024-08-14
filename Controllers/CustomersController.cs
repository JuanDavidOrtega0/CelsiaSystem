using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CelsiaProject.Data;
using CelsiaProject.Models;
using CelsiaProject.Services;

public class CustomersController : Controller
{
    private readonly CelsiaContext _context;

    public CustomersController(CelsiaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _context.Customers.ToListAsync());
        }
        catch
        {
            return ViewBag.Error = "Error al listar las transacciones";
        }
    }
}