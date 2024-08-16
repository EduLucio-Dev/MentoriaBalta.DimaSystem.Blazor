using DimaSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DimaSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Category> Categories { get; set; } = null!;
        DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
