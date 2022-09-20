using Manager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Regiao)
                .IsRequired()
                .HasColumnName("Regiao")
                .HasColumnType("VARCHAR(100)");


            builder.Property(c => c.Disponivel)
                .IsRequired()
                .HasColumnName("Disponivel")
                .HasColumnType("BIT");


            builder.HasMany(x => x.Oportunidades)
               .WithOne(x => x.Usuario)
               .HasConstraintName("FK_Usuario_Oportunidade");
        }
    }
}
