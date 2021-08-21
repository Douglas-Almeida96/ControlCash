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
    public class CartaosController : Controller
    {
        private Context db = new Context();

        // GET: Cartaos
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var cartaos = from c in db.Cartaos
                          select c;
            cartaos = cartaos.Where(c => c.UserID.Contains(id));
            return View(cartaos.ToList());
        }

        // GET: Cartaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartaos.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // GET: Cartaos/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            ViewBag.TipoCartaoId = new SelectList(db.TipoCartaos, "id", "Tipo");
            return View();
        }

        // POST: Cartaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstituicaoId,TipoCartaoId,Nome,Saldo,limite,UserID")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Cartaos.Add(cartao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", cartao.InstituicaoId);
            ViewBag.TipoCartaoId = new SelectList(db.TipoCartaos, "id", "Tipo", cartao.TipoCartaoId);
            return View(cartao);
        }

        // GET: Cartaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartaos.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", cartao.InstituicaoId);
            ViewBag.TipoCartaoId = new SelectList(db.TipoCartaos, "id", "Tipo", cartao.TipoCartaoId);
            return View(cartao);
        }

        // POST: Cartaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstituicaoId,TipoCartaoId,Nome,Saldo,limite,UserID")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", cartao.InstituicaoId);
            ViewBag.TipoCartaoId = new SelectList(db.TipoCartaos, "id", "Tipo", cartao.TipoCartaoId);
            return View(cartao);
        }

        // GET: Cartaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartaos.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // POST: Cartaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cartao cartao = db.Cartaos.Find(id);
            db.Cartaos.Remove(cartao);
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
