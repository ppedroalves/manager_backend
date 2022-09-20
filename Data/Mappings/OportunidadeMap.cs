using Manager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Mappings
{
    public class OportunidadeMap : IEntityTypeConfiguration<Oportunidade>
    {
        public void Configure(EntityTypeBuilder<Oportunidade> builder)
        {
            builder.ToTable("Oportunidade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnName("Cnpj")
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasColumnName("RazaoSocial")
                .HasColumnType("VARCHAR(100)");


            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("FLOAT");


            builder.HasOne(x => x.Usuario)
               .WithMany(x => x.Oportunidades)
               .HasConstraintName("FK_Oportunidade_Usuario");
        }
    }
}
