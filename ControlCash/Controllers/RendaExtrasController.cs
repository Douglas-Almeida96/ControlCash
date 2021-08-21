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
    public class RendaExtrasController : Controller
    {
        private Context db = new Context();

        // GET: RendaExtras
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var renda = from c in db.RendaExtras
                          select c;
            renda = renda.Where(c => c.UserID.Contains(id));
            return View(renda.ToList());
        }

        // GET: RendaExtras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendaExtra rendaExtra = db.RendaExtras.Find(id);
            if (rendaExtra == null)
            {
                return HttpNotFound();
            }
            return View(rendaExtra);
        }

        // GET: RendaExtras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RendaExtras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Date,Valor,UserID")] RendaExtra rendaExtra)
        {
            if (ModelState.IsValid)
            {
                db.RendaExtras.Add(rendaExtra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rendaExtra);
        }

        // GET: RendaExtras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendaExtra rendaExtra = db.RendaExtras.Find(id);
            if (rendaExtra == null)
            {
                return HttpNotFound();
            }
            return View(rendaExtra);
        }

        // POST: RendaExtras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Date,Valor,UserID")] RendaExtra rendaExtra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rendaExtra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rendaExtra);
        }

        // GET: RendaExtras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendaExtra rendaExtra = db.RendaExtras.Find(id);
            if (rendaExtra == null)
            {
                return HttpNotFound();
            }
            return View(rendaExtra);
        }

        // POST: RendaExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RendaExtra rendaExtra = db.RendaExtras.Find(id);
            db.RendaExtras.Remove(rendaExtra);
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
