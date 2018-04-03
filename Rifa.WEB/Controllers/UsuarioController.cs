using Rifa.DAL;
using Rifa.Entidades;
using Rifa.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rifa.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult CadastrarUsuario(UsuarioCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio rep = new UsuarioRepositorio();
                    Usuario u = new Usuario();

                    u.Nome = model.Nome;
                    u.Email = model.Email;
                    u.Senha = model.Senha;

                    rep.Insert(u);
                }
                catch (Exception ex)
                {
                    return Json($"Ocorreu um  erro: {ex.Message}");
                }
                return Json("Usuário cadastrado com sucesso!");
            }
            else
            {
                return Json("");
            }
        }
    }
}