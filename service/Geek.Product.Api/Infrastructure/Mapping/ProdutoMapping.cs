using Geek.Product.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geek.Product.Api.Infrastructure.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(t => t.IdProduto);
            builder.Property(t => t.NomeCategoria).HasColumnName("NomeCategoria").IsRequired();
            builder.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(255).IsRequired();
            builder.Property(t => t.Descricao).HasColumnName("Descricao").HasMaxLength(255).IsRequired();
            builder.Property(t => t.Preco).HasColumnName("Preco").IsRequired();
            builder.Property(t => t.ImageURL).HasColumnName("ImageURL").IsRequired();
            builder.Property(t => t.DataHoraCadastro).HasColumnName("DataHoraCadastro").IsRequired();
        }
    }
}
