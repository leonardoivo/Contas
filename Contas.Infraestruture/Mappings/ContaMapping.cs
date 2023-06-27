

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contas.Domain.Models;

namespace Contas.Infrastructure.Mappings
{
    class ClienteMapping : IEntityTypeConfiguration<ContaModel>
    {
        public void Configure(EntityTypeBuilder<ContaModel> builder)
        {
            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.ContaId)
              .HasColumnName("ContaId");

            builder.Property(ep => ep.Nome)
             .HasColumnName("Nome");

            builder.Property(ep => ep.Descricao)
             .HasColumnName("Descricao");

            builder.ToTable("Conta", "Contas");
        }
    }
}
