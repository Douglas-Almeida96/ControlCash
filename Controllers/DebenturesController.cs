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
    public class DebenturesController : Controller
    {
        private Context db = new Context();

        // GET: Debentures
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var debentures = from c in db.Debentures
                          select c;
            debentures = debentures.Where(c => c.UserID.Contains(id));
            return View(debentures.ToList());
        }

        // GET: Debentures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debenture debenture = db.Debentures.Find(id);
            if (debenture == null)
            {
                return HttpNotFound();
            }
            return View(debenture);
        }

        // GET: Debentures/Create
        public ActionResult Create()
        {
            List<SelectListItem> Lista = new List<SelectListItem>();
            Lista.Add(new SelectListItem
            {
                Text = "Valor",
                Value = "Valor"
            });
            Lista.Add(new SelectListItem
            {
                Text = "Quantidade",
                Value = "Quantidade"
            });
            ViewBag.Aplica_por = Lista;
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome");
            return View();
        }

        // POST: Debentures/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DebentureID,InstituicaoId,Debenture_Escolhido,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Debenture debenture)
        {
            if (ModelState.IsValid)
            {
                db.Debentures.Add(debenture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", debenture.InstituicaoId);
            return View(debenture);
        }

        // GET: Debentures/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> Lista = new List<SelectListItem>();
            Lista.Add(new SelectListItem
            {
                Text = "Valor",
                Value = "Valor"
            });
            Lista.Add(new SelectListItem
            {
                Text = "Quantidade",
                Value = "Quantidade"
            });
            ViewBag.Aplica_por = Lista;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debenture debenture = db.Debentures.Find(id);
            if (debenture == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", debenture.InstituicaoId);
            return View(debenture);
        }

        // POST: Debentures/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DebentureID,InstituicaoId,Debenture_Escolhido,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Debenture debenture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debenture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", debenture.InstituicaoId);
            return View(debenture);
        }

        // GET: Debentures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debenture debenture = db.Debentures.Find(id);
            if (debenture == null)
            {
                return HttpNotFound();
            }
            return View(debenture);
        }

        // POST: Debentures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Debenture debenture = db.Debentures.Find(id);
            db.Debentures.Remove(debenture);
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
