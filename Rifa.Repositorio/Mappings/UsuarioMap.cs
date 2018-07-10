using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Rifa.Entidades;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rifa.Repositorio.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(u => u.IdUsuario);

            Property(u => u.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("NomeUsuario")
                .HasMaxLength(250)
                .IsRequired();

            Property(u => u.Email)
                .HasColumnName("EmailUsuario")
                .HasMaxLength(250)
                .IsRequired();

            Property(u => u.Login)
                .HasColumnName("Login")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            Property(u => u.Foto)
                .HasColumnName("FotoUsuario")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                     new IndexAnnotation(new IndexAttribute
                                    ("ix_Foto")
                                    { IsUnique = true }));

            HasRequired(u => u.Perfil)
              .WithMany(p => p.Usuarios)
              .Map(m => m.MapKey("IdPerfil"));

        }
    }
}
