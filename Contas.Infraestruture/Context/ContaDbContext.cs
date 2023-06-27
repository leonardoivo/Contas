using Microsoft.EntityFrameworkCore;
using Contas.Domain.Models;

namespace Contas.Infrastructure.Context
{
    public class ContaDbContext : DbContext
    {

        public ContaDbContext(DbContextOptions<ContaDbContext> options) : base(options)
        { }

       
        public DbSet<ContaModel> Conta { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContaDbContext).Assembly);
        }
    }
}