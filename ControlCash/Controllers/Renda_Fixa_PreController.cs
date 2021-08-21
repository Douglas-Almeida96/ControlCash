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
    public class Renda_Fixa_PreController : Controller
    {
        private Context db = new Context();

        // GET: Renda_Fixa_Pre
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var renda_Fixa_Pre = from c in db.Renda_Fixa_Pre
                          select c;
            renda_Fixa_Pre = renda_Fixa_Pre.Where(c => c.UserID.Contains(id));
            return View(renda_Fixa_Pre.ToList());
        }

        // GET: Renda_Fixa_Pre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pre renda_Fixa_Pre = db.Renda_Fixa_Pre.Find(id);
            if (renda_Fixa_Pre == null)
            {
                return HttpNotFound();
            }
            return View(renda_Fixa_Pre);
        }

        // GET: Renda_Fixa_Pre/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Renda_Fixa_Pre/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Renda_PreID,InstituicaoId,Emissor,Papel,Taxa_Juros_Ano,Data_Inicio,Data_Venc,Valor_Aplicado,UserID")] Renda_Fixa_Pre renda_Fixa_Pre)
        {
            if (ModelState.IsValid)
            {
                db.Renda_Fixa_Pre.Add(renda_Fixa_Pre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pre.InstituicaoId);
            return View(renda_Fixa_Pre);
        }

        // GET: Renda_Fixa_Pre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pre renda_Fixa_Pre = db.Renda_Fixa_Pre.Find(id);
            if (renda_Fixa_Pre == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pre.InstituicaoId);
            return View(renda_Fixa_Pre);
        }

        // POST: Renda_Fixa_Pre/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Renda_PreID,InstituicaoId,Emissor,Papel,Taxa_Juros_Ano,Data_Inicio,Data_Venc,Valor_Aplicado,UserID")] Renda_Fixa_Pre renda_Fixa_Pre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renda_Fixa_Pre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pre.InstituicaoId);
            return View(renda_Fixa_Pre);
        }

        // GET: Renda_Fixa_Pre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pre renda_Fixa_Pre = db.Renda_Fixa_Pre.Find(id);
            if (renda_Fixa_Pre == null)
            {
                return HttpNotFound();
            }
            return View(renda_Fixa_Pre);
        }

        // POST: Renda_Fixa_Pre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renda_Fixa_Pre renda_Fixa_Pre = db.Renda_Fixa_Pre.Find(id);
            db.Renda_Fixa_Pre.Remove(renda_Fixa_Pre);
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
