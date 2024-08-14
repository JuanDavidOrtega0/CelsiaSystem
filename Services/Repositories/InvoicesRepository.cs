using CelsiaProject.Models;
using CelsiaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CelsiaProject.Services;

public class InvoicesRepository : IInvoicesRepository
{
    private readonly CelsiaContext _context;
    
    public InvoicesRepository(CelsiaContext context)
    {
        _context = context;
    }

    public void AddInvoice(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        _context.SaveChanges();
    }

    public void UpdateInvoice(string id, Invoice invoice)
    {
        var existingInvoice = _context.Invoices.FirstOrDefault(t => t.Id == id);
        if (existingInvoice != null)
        {
            _context.Invoices.Update(invoice);
            _context.SaveChanges();
        }
    }

    public void DeleteInvoice(string id)
    {
        var existingInvoice = _context.Invoices.FirstOrDefault(t => t.Id == id);
        if (existingInvoice!= null)
        {
            _context.Invoices.Remove(existingInvoice);
            _context.SaveChanges();
        }
    }
}