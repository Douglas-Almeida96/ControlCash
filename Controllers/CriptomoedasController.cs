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
    public class CriptomoedasController : Controller
    {
        private Context db = new Context();

        // GET: Criptomoedas
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var criptomoedas = from c in db.Criptomoedas
                          select c;
            criptomoedas = criptomoedas.Where(c => c.UserID.Contains(id)); 
            return View(criptomoedas.ToList());
        }

        // GET: Criptomoedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            return View(criptomoeda);
        }

        // GET: Criptomoedas/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Criptomoedas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriptomoedaID,InstituicaoId,Tipo_Moeda,Quantidade,Preco_Compra,Data_Inicio,UserID")] Criptomoeda criptomoeda)
        {
            if (ModelState.IsValid)
            {
                db.Criptomoedas.Add(criptomoeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", criptomoeda.InstituicaoId);
            return View(criptomoeda);
        }

        // GET: Criptomoedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", criptomoeda.InstituicaoId);
            return View(criptomoeda);
        }

        // POST: Criptomoedas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriptomoedaID,InstituicaoId,Tipo_Moeda,Quantidade,Preco_Compra,Data_Inicio,UserID")] Criptomoeda criptomoeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criptomoeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", criptomoeda.InstituicaoId);
            return View(criptomoeda);
        }

        // GET: Criptomoedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            if (criptomoeda == null)
            {
                return HttpNotFound();
            }
            return View(criptomoeda);
        }

        // POST: Criptomoedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criptomoeda criptomoeda = db.Criptomoedas.Find(id);
            db.Criptomoedas.Remove(criptomoeda);
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
