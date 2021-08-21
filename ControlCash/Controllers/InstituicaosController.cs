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
    public class InstituicaosController : Controller
    {
        private Context db = new Context();

        // GET: Instituicaos
        public ActionResult Index()
        {
            return View(db.Instituicoes.ToList());
        }

        // GET: Instituicaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Instituicoes.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }

        // GET: Instituicaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicoes.Find(id);
            db.Instituicoes.Remove(instituicao);
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
