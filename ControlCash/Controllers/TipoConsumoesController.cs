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
    public class TipoConsumoesController : Controller
    {
        private Context db = new Context();

        // GET: TipoConsumoes
        public ActionResult Index()
        {
            return View(db.TipoConsumoes.ToList());
        }

        // GET: TipoConsumoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsumo tipoConsumo = db.TipoConsumoes.Find(id);
            if (tipoConsumo == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoConsumoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] TipoConsumo tipoConsumo)
        {
            if (ModelState.IsValid)
            {
                db.TipoConsumoes.Add(tipoConsumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsumo tipoConsumo = db.TipoConsumoes.Find(id);
            if (tipoConsumo == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsumo);
        }

        // POST: TipoConsumoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] TipoConsumo tipoConsumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoConsumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoConsumo);
        }

        // GET: TipoConsumoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsumo tipoConsumo = db.TipoConsumoes.Find(id);
            if (tipoConsumo == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsumo);
        }

        // POST: TipoConsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoConsumo tipoConsumo = db.TipoConsumoes.Find(id);
            db.TipoConsumoes.Remove(tipoConsumo);
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
