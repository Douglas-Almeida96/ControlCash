using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlCash.Models;

namespace ControlCash.Controllers
{
    public class MoedasController : Controller
    {
        private Context db = new Context();

        // GET: Moedas
        public ActionResult Index()
        {
            var moedas = db.Moedas.Include(m => m.Instituicao);
            return View(moedas.ToList());
        }

        // GET: Moedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moedas.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // GET: Moedas/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Moedas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoedaID,InstituicaoId,Tipo_Moeda,Cotacao,Valor_Comprado,Data_Inicio,UserID")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Moedas.Add(moeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", moeda.InstituicaoId);
            return View(moeda);
        }

        // GET: Moedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moedas.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", moeda.InstituicaoId);
            return View(moeda);
        }

        // POST: Moedas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoedaID,InstituicaoId,Tipo_Moeda,Cotacao,Valor_Comprado,Data_Inicio,UserID")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", moeda.InstituicaoId);
            return View(moeda);
        }

        // GET: Moedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moedas.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // POST: Moedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moeda moeda = db.Moedas.Find(id);
            db.Moedas.Remove(moeda);
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
