using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeusLembretes.com.Models;

namespace MeusLembretes.com.Controllers
{
    public class LembretesController : Controller
    {
        private LembreteContext db = new LembreteContext();

        // GET: Lembretes
        public ActionResult Index()
        {
            var lembretes = db.Lembretes.Include(l => l.Usuarioy);
            return View(lembretes.ToList());
        }

        // GET: Lembretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.Lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            return View(lembrete);
        }

        // GET: Lembretes/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Lembretes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LembreteId,UsuarioId,Titulo,Mensagem,RealizacaoData,DataCadastro,Modificacao")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                db.Lembretes.Add(lembrete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "UsuarioNome", lembrete.UsuarioId);
            return View(lembrete);
        }

        // GET: Lembretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.Lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "UsuarioNome", lembrete.UsuarioId);
            return View(lembrete);
        }

        // POST: Lembretes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LembreteId,UsuarioId,Titulo,Mensagem,RealizacaoData,DataCadastro,Modificacao")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lembrete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "UsuarioNome", lembrete.UsuarioId);
            return View(lembrete);
        }

        // GET: Lembretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.Lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            return View(lembrete);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lembrete lembrete = db.Lembretes.Find(id);
            db.Lembretes.Remove(lembrete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
