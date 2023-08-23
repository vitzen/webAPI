using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Payments.Model.Models;

namespace Payments.Db;

public class PaymentsDbContext : DbContext
{
    private const string ConnectionString = "Host=localhost;Username=postgres;Password=root;Database=Maxima";
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    public PaymentsDbContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}