using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rifa.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Rifa.Repositorio.Mappings
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(p => p.IdPerfil);

            Property(p => p.IdPerfil)
                .HasColumnName("IdPerfil")
                .IsRequired();

            Property(p => p.NomePerfil)
                .HasColumnName("NomePerfil")
                .IsRequired();
        }
    }
}
