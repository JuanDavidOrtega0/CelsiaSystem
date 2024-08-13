namespace CelsiaProject.Models;

public class Transaction
{
    public required string Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int Amount { get; set; }

    public required string Status { get; set; }

    public required string Type { get; set; }
}