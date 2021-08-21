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
    public class PoupancasController : Controller
    {
        private Context db = new Context();

        // GET: Poupancas
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var poupancas = from c in db.Poupancas
                          select c;
            poupancas = poupancas.Where(c => c.UserID.Contains(id));
            return View(poupancas.ToList());
        }

        // GET: Poupancas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poupanca poupanca = db.Poupancas.Find(id);
            if (poupanca == null)
            {
                return HttpNotFound();
            }
            return View(poupanca);
        }

        // GET: Poupancas/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Poupancas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoupancaID,InstituicaoId,Valor_Aplicado,Data_Inicio,UserID")] Poupanca poupanca)
        {
            if (ModelState.IsValid)
            {
                db.Poupancas.Add(poupanca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", poupanca.InstituicaoId);
            return View(poupanca);
        }

        // GET: Poupancas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poupanca poupanca = db.Poupancas.Find(id);
            if (poupanca == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", poupanca.InstituicaoId);
            return View(poupanca);
        }

        // POST: Poupancas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoupancaID,InstituicaoId,Valor_Aplicado,Data_Inicio,UserID")] Poupanca poupanca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poupanca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", poupanca.InstituicaoId);
            return View(poupanca);
        }

        // GET: Poupancas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poupanca poupanca = db.Poupancas.Find(id);
            if (poupanca == null)
            {
                return HttpNotFound();
            }
            return View(poupanca);
        }

        // POST: Poupancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poupanca poupanca = db.Poupancas.Find(id);
            db.Poupancas.Remove(poupanca);
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
