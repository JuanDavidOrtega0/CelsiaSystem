namespace CelsiaProject.Models;

public class Invoice
{
    public required string Id { get; set; }

    public required string Period { get; set; }
    
    public required int InvoicedAmount { get; set; }

    public required int AmountPaid { get; set; }
}