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
    public class TipoCartaosController : Controller
    {
        private Context db = new Context();

        // GET: TipoCartaos
        public ActionResult Index()
        {
            return View(db.TipoCartaos.ToList());
        }

        // GET: TipoCartaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCartao tipoCartao = db.TipoCartaos.Find(id);
            if (tipoCartao == null)
            {
                return HttpNotFound();
            }
            return View(tipoCartao);
        }

        // GET: TipoCartaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCartaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tipo")] TipoCartao tipoCartao)
        {
            if (ModelState.IsValid)
            {
                db.TipoCartaos.Add(tipoCartao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCartao);
        }

        // GET: TipoCartaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCartao tipoCartao = db.TipoCartaos.Find(id);
            if (tipoCartao == null)
            {
                return HttpNotFound();
            }
            return View(tipoCartao);
        }

        // POST: TipoCartaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tipo")] TipoCartao tipoCartao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCartao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCartao);
        }

        // GET: TipoCartaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCartao tipoCartao = db.TipoCartaos.Find(id);
            if (tipoCartao == null)
            {
                return HttpNotFound();
            }
            return View(tipoCartao);
        }

        // POST: TipoCartaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCartao tipoCartao = db.TipoCartaos.Find(id);
            db.TipoCartaos.Remove(tipoCartao);
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
