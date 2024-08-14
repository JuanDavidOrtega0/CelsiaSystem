using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CelsiaProject.Data;
using CelsiaProject.Models;
using CelsiaProject.Services;

public class TransactionsController : Controller
{
    private readonly ITransactionRepository _transactionRepository;

    private readonly CelsiaContext _context;

    public TransactionsController(ITransactionRepository transactionRepository, CelsiaContext context)
    {
        _transactionRepository = transactionRepository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _context.Transactions.ToListAsync());
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
    public IActionResult Create(Transaction transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _transactionRepository.AddTransaction(transaction);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View(transaction);
        }
    }
}