using Microsoft.AspNetCore.Mvc;
using CelsiaProject.Models;
using CelsiaProject.Data;
using ClosedXML.Excel;

public class ExcelController : Controller
{
    private readonly CelsiaContext _context;

    public ExcelController(CelsiaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> ImportExcel(IFormFile excel)
    {
        var workbook = new XLWorkbook(excel.OpenReadStream());

        var sheet = workbook.Worksheet(1);

        var FirstRow = sheet.FirstRowUsed().RangeAddress.FirstAddress.RowNumber;
        var LastRow = sheet.LastRowUsed().RangeAddress.FirstAddress.RowNumber;

        var transactions = new List<Transaction>();
        var invoices = new List<Invoice>();
        var customers = new List<Customer>();

        for (int i = FirstRow + 1; i < LastRow; i++)
        {
            var row = sheet.Row(i);

            var transaction = new Transaction
            {
                Id = row.Cell(1).GetValue<string>(),
                DateTime = row.Cell(2).GetValue<DateTime>(),
                Amount = row.Cell(3).GetValue<int>(),
                Status = row.Cell(4).GetValue<string>(),
                Type = row.Cell(5).GetValue<string>()
            };

            var customer = new Customer
            {
                Name = row.Cell(6).GetValue<string>(),
                Document = row.Cell(7).GetValue<string>(),
                Address = row.Cell(8).GetValue<string>(),
                PhoneNumber = row.Cell(9).GetValue<string>(),
                Email = row.Cell(10).GetValue<string>(),
                UsedPlatform = row.Cell(11).GetValue<string>()
            };

            var invoice = new Invoice
            {
                Id = row.Cell(12).GetValue<string>(),
                Period = row.Cell(13).GetValue<string>(),
                InvoicedAmount = row.Cell(14).GetValue<int>(),
                AmountPaid = row.Cell(15).GetValue<int>()
            };

            transactions.Add(transaction);
            customers.Add(customer);
            invoices.Add(invoice);
        }

        await _context.Transactions.AddRangeAsync(transactions);
        await _context.Customers.AddRangeAsync(customers);
        await _context.Invoices.AddRangeAsync(invoices);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }
}