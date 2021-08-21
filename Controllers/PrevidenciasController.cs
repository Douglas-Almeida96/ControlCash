using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlCash.Models;
using Microsoft.AspNet.Identity;

namespace ControlCash.Controllers
{
    [Authorize]
    public class PrevidenciasController : Controller
    {
        private Context db = new Context();

        // GET: Previdencias
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var previdencias = from c in db.Previdencias
                          select c;
            previdencias = previdencias.Where(c => c.UserID.Contains(id));
            return View(previdencias.ToList());
        }

        // GET: Previdencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previdencia previdencia = db.Previdencias.Find(id);
            if (previdencia == null)
            {
                return HttpNotFound();
            }
            return View(previdencia);
        }

        // GET: Previdencias/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Previdencias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrevidenciaID,InstituicaoId,Fundo,Valor_Aplicado,Data_Inicio,UserID")] Previdencia previdencia)
        {
            if (ModelState.IsValid)
            {
                db.Previdencias.Add(previdencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", previdencia.InstituicaoId);
            return View(previdencia);
        }

        // GET: Previdencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previdencia previdencia = db.Previdencias.Find(id);
            if (previdencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", previdencia.InstituicaoId);
            return View(previdencia);
        }

        // POST: Previdencias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrevidenciaID,InstituicaoId,Fundo,Valor_Aplicado,Data_Inicio,UserID")] Previdencia previdencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previdencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", previdencia.InstituicaoId);
            return View(previdencia);
        }

        // GET: Previdencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previdencia previdencia = db.Previdencias.Find(id);
            if (previdencia == null)
            {
                return HttpNotFound();
            }
            return View(previdencia);
        }

        // POST: Previdencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Previdencia previdencia = db.Previdencias.Find(id);
            db.Previdencias.Remove(previdencia);
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
