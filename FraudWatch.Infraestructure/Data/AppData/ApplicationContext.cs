
using FraudWatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FraudWatch.Infraestructure.Data.AppData;

public class ApplicationContext : DbContext
{
    public DbSet<AnalistaEntity> Analistas { get; set; }
    public DbSet<DentistaEntity> Dentistas { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
