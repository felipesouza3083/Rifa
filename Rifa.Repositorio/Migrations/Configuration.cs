namespace Rifa.Repositorio.Migrations
{
    using Rifa.Entidades;
    using Rifa.Repositorio.Util;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rifa.Repositorio.Context.DataContext>
    {
        public Configuration()
        {
            //permissão para CREATE ou ALTER na base de dados
            AutomaticMigrationsEnabled = true;
            //permissão para DROP..
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Rifa.Repositorio.Context.DataContext context)
        {
            context.Perfil.AddOrUpdate(
                new Perfil { IdPerfil = 1, NomePerfil = "Administrador" },
                new Perfil { IdPerfil = 2, NomePerfil = "Funcionário" },
                new Perfil { IdPerfil = 3, NomePerfil = "Cliente" }
            );
        }
    }
}
