namespace Rifa.Repositorio.Migrations
{
    using Rifa.Entidades;
    using Rifa.Repositorio.Util;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rifa.Repositorio.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Rifa.Repositorio.Context.DataContext context)
        {
            /*context.Perfil.AddOrUpdate(
                new Perfil { IdPerfil = 1, NomePerfil = "Adminstrador",
                             Usuarios = new List<Usuario> {
                                 new Usuario
                                 {
                                    IdUsuario = 1,
                                    Nome = "Felipe Souza",
                                    Email = "felipearaujosouza@hotmail.com",
                                    Login = "felipe.souza",
                                    Senha = Criptografia.EncriptarSenhaMD5("cd3083"),
                                    DataCadastro = DateTime.Now
                                 }
                             }
                },
                new Perfil { IdPerfil = 2, NomePerfil = "Comum" }
                );*/
            context.Perfil.AddOrUpdate(
                new Perfil{IdPerfil = 1,NomePerfil = "Adminstrador"},
                new Perfil { IdPerfil = 2, NomePerfil = "Comum" }
            );
            context.Usuario.AddOrUpdate(
                new Usuario
                {
                    IdUsuario = 1,
                    Nome = "Felipe Souza",
                    Email = "felipearaujosouza@hotmail.com",
                    Login = "felipe.souza",
                    Senha = Criptografia.EncriptarSenhaMD5("cd3083"),
                    DataCadastro = DateTime.Now,
                    IdPerfil = 1
                }
                );
        }
    }
}
