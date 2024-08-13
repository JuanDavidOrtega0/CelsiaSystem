namespace CelsiaProject.Models;

public class Customer
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Document { get; set; }

    public required string Address { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Email { get; set; }

    public required string UsedPlatform { get; set; }
}