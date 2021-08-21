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
    public class Tesouro_DiretoController : Controller
    {
        private Context db = new Context();

        // GET: Tesouro_Direto
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var tesouro_Direto = from c in db.Tesouro_Direto
                          select c;
            tesouro_Direto = tesouro_Direto.Where(c => c.UserID.Contains(id));
            return View(tesouro_Direto.ToList());
        }

        // GET: Tesouro_Direto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesouro_Direto tesouro_Direto = db.Tesouro_Direto.Find(id);
            if (tesouro_Direto == null)
            {
                return HttpNotFound();
            }
            return View(tesouro_Direto);
        }

        // GET: Tesouro_Direto/Create
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

        // POST: Tesouro_Direto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TesousoID,InstituicaoId,Titulo,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Tesouro_Direto tesouro_Direto)
        {
            if (ModelState.IsValid)
            {
                db.Tesouro_Direto.Add(tesouro_Direto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", tesouro_Direto.InstituicaoId);
            return View(tesouro_Direto);
        }

        // GET: Tesouro_Direto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesouro_Direto tesouro_Direto = db.Tesouro_Direto.Find(id);
            if (tesouro_Direto == null)
            {
                return HttpNotFound();
            }

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

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", tesouro_Direto.InstituicaoId);
            return View(tesouro_Direto);
        }

        // POST: Tesouro_Direto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TesousoID,InstituicaoId,Titulo,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Tesouro_Direto tesouro_Direto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tesouro_Direto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", tesouro_Direto.InstituicaoId);
            return View(tesouro_Direto);
        }

        // GET: Tesouro_Direto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesouro_Direto tesouro_Direto = db.Tesouro_Direto.Find(id);
            if (tesouro_Direto == null)
            {
                return HttpNotFound();
            }
            return View(tesouro_Direto);
        }

        // POST: Tesouro_Direto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tesouro_Direto tesouro_Direto = db.Tesouro_Direto.Find(id);
            db.Tesouro_Direto.Remove(tesouro_Direto);
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
