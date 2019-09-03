using MeusLembretes.com.Models;
using MeusLembretes.com.ViewModels;
using MeusLembretes.com.Utils;
using System;
using System.Web.Mvc;

namespace MeusLembretes.com.Controllers
{
    public class AutenticacaoController : Controller
    {
        private LembreteContext db = new LembreteContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(UsuarioViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(ViewModel);
            }
            Usuario usuario = new Usuario
            {
                UsuarioNome = ViewModel.UsuarioNome,
                Telefone = ViewModel.Telefone,
                Senha = Hash.GerarHash(ViewModel.Senha),
                Ativo = ViewModel.Ativo = true,
                Email = ViewModel.Email,
                DataCadastro = ViewModel.DataCadastro = DateTime.Now
            };

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }
}