using CelsiaProject.Models;
using CelsiaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CelsiaProject.Services;

public class TransactionRepository : ITransactionRepository
{
    private readonly CelsiaContext _context;
    
    public TransactionRepository(CelsiaContext context)
    {
        _context = context;
    }

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public void UpdateTransaction(string id, Transaction transaction)
    {
        var existingTransaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
        if (existingTransaction != null)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }
    }

    public void DeleteTransaction(string id)
    {
        var existingTransaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
        if (existingTransaction!= null)
        {
            _context.Transactions.Remove(existingTransaction);
            _context.SaveChanges();
        }
    }
}