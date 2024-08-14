using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CelsiaProject.Data;
using CelsiaProject.Models;
using CelsiaProject.Services;

public class InvoicesController : Controller
{
    private readonly CelsiaContext _context;

    private readonly IInvoicesRepository _invoicesRepository;

    public InvoicesController(CelsiaContext context, IInvoicesRepository invoicesRepository)
    {
        _context = context;
        _invoicesRepository = invoicesRepository;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _context.Invoices.ToListAsync());
        }
        catch
        {
            return ViewBag.Error = "Error al listar las transacciones";
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Invoice invoice)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _invoicesRepository.AddInvoice(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View(invoice);
        }
    }
}