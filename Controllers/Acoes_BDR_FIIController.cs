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
    public class Acoes_BDR_FIIController : Controller
    {
        private Context db = new Context();

        // GET: Acoes_BDR_FII
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var acoes_BDR_FII = from c in db.Acoes_BDR_FII
                                select c;
            acoes_BDR_FII = acoes_BDR_FII.Where(c => c.UserID.Contains(id));
            return View(acoes_BDR_FII.ToList());
        }

        // GET: Acoes_BDR_FII/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acoes_BDR_FII acoes_BDR_FII = db.Acoes_BDR_FII.Find(id);
            if (acoes_BDR_FII == null)
            {
                return HttpNotFound();
            }
            return View(acoes_BDR_FII);
        }

        // GET: Acoes_BDR_FII/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Acoes_BDR_FII/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Acoes_BDR_FIIID,InstituicaoId,Ativo,Quantidade,Preco_Compra,Data_Inicio,Taxa,UserID")] Acoes_BDR_FII acoes_BDR_FII)
        {
            if (ModelState.IsValid)
            {
                db.Acoes_BDR_FII.Add(acoes_BDR_FII);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", acoes_BDR_FII.InstituicaoId);
            return View(acoes_BDR_FII);
        }

        // GET: Acoes_BDR_FII/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acoes_BDR_FII acoes_BDR_FII = db.Acoes_BDR_FII.Find(id);
            if (acoes_BDR_FII == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", acoes_BDR_FII.InstituicaoId);
            return View(acoes_BDR_FII);
        }

        // POST: Acoes_BDR_FII/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Acoes_BDR_FIIID,InstituicaoId,Ativo,Quantidade,Preco_Compra,Data_Inicio,Taxa,UserID")] Acoes_BDR_FII acoes_BDR_FII)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acoes_BDR_FII).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", acoes_BDR_FII.InstituicaoId);
            return View(acoes_BDR_FII);
        }

        // GET: Acoes_BDR_FII/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acoes_BDR_FII acoes_BDR_FII = db.Acoes_BDR_FII.Find(id);
            if (acoes_BDR_FII == null)
            {
                return HttpNotFound();
            }
            return View(acoes_BDR_FII);
        }

        // POST: Acoes_BDR_FII/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acoes_BDR_FII acoes_BDR_FII = db.Acoes_BDR_FII.Find(id);
            db.Acoes_BDR_FII.Remove(acoes_BDR_FII);
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
