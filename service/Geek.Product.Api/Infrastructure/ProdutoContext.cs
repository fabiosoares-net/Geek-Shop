using Geek.Product.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Geek.Product.Api.Infrastructure
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
