using Newtonsoft.Json;
using Rifa.Entidades;
using Rifa.Repositorio.Contracts;
using Rifa.Repositorio.Util;
using Rifa.WEB.Models.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rifa.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public void SalvarFoto()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Imagens/Usuarios"), fileName);
                file.SaveAs(path);
            }

        }

        [HttpPost]
        public JsonResult CadastrarUsuario(UsuarioCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.HasLogin(model.Login))
                    {
                        return Json("Login já cadastrado na base de dados!");
                    }
                    else
                    {
                        Usuario u = new Usuario();

                        u.Nome = model.Nome;
                        u.Email = model.Email;
                        u.Login = model.Login;
                        u.Senha = Criptografia.EncriptarSenhaMD5(model.Senha);
                        u.Foto = model.Foto;
                        u.DataCadastro = DateTime.Now;
                        u.IdPerfil = model.IdPerfil;

                        repository.Insert(u);

                        return Json("Usuario Cadastrado com sucesso!");
                    }
                }
                else
                {
                    return Json(ModelState);
                }
            }
            catch (Exception e)
            {
                return Json($"Ocorreu um erro:{e.Message}");
            }
        }

        [HttpPost]
        public JsonResult AutenticarUsuario(UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario u = repository.Find(model.Login, Criptografia.EncriptarSenhaMD5(model.Senha));
                if (u != null)
                {
                    UsuarioAutenticadoViewModel auth = new UsuarioAutenticadoViewModel();

                    auth.IdUsuario = u.IdUsuario;
                    auth.Nome = u.Nome;
                    auth.Login = u.Login;
                    auth.DataHoraAcesso = DateTime.Now;

                    //converter o objeto para JSON..
                    string authJSON = JsonConvert.SerializeObject(auth);

                    //criar o ticket de acesso..
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(authJSON, false, 5);

                    //gravar o ticket em cookie..
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);

                    return Json(new { redirectTo = Url.Action("Index", "Principal", new { area = "RestrictArea" }), }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Usuário e Senha incorretos.");
                }
            }
            else
            {
                return Json(ModelState);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Usuario", new { area = "" });
        }
    }
}