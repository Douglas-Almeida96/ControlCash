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
    public class Renda_Fixa_PosController : Controller
    {
        private Context db = new Context();

        // GET: Renda_Fixa_Pos
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var renda_Fixa_Pos = from c in db.Renda_Fixa_Pos
                          select c;
            renda_Fixa_Pos = renda_Fixa_Pos.Where(c => c.UserID.Contains(id));
            return View(renda_Fixa_Pos.ToList());
        }

        // GET: Renda_Fixa_Pos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pos renda_Fixa_Pos = db.Renda_Fixa_Pos.Find(id);
            if (renda_Fixa_Pos == null)
            {
                return HttpNotFound();
            }
            return View(renda_Fixa_Pos);
        }

        // GET: Renda_Fixa_Pos/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Renda_Fixa_Pos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Renda_PosID,InstituicaoId,Emissor,Papel,Indexador,Porcentagem,Data_Inicio,Data_Venc,Valor_Aplicado,UserID")] Renda_Fixa_Pos renda_Fixa_Pos)
        {
            if (ModelState.IsValid)
            {
                db.Renda_Fixa_Pos.Add(renda_Fixa_Pos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pos.InstituicaoId);
            return View(renda_Fixa_Pos);
        }

        // GET: Renda_Fixa_Pos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pos renda_Fixa_Pos = db.Renda_Fixa_Pos.Find(id);
            if (renda_Fixa_Pos == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pos.InstituicaoId);
            return View(renda_Fixa_Pos);
        }

        // POST: Renda_Fixa_Pos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Renda_PosID,InstituicaoId,Emissor,Papel,Indexador,Porcentagem,Data_Inicio,Data_Venc,Valor_Aplicado,UserID")] Renda_Fixa_Pos renda_Fixa_Pos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renda_Fixa_Pos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", renda_Fixa_Pos.InstituicaoId);
            return View(renda_Fixa_Pos);
        }

        // GET: Renda_Fixa_Pos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renda_Fixa_Pos renda_Fixa_Pos = db.Renda_Fixa_Pos.Find(id);
            if (renda_Fixa_Pos == null)
            {
                return HttpNotFound();
            }
            return View(renda_Fixa_Pos);
        }

        // POST: Renda_Fixa_Pos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renda_Fixa_Pos renda_Fixa_Pos = db.Renda_Fixa_Pos.Find(id);
            db.Renda_Fixa_Pos.Remove(renda_Fixa_Pos);
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
