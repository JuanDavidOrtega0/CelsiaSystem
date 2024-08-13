using Microsoft.EntityFrameworkCore;
using CelsiaProject.Models;

namespace CelsiaProject.Data;

public class CelsiaContext : DbContext
{
    public CelsiaContext(DbContextOptions<CelsiaContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
}