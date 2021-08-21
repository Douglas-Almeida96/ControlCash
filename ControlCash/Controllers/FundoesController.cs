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
    public class FundoesController : Controller
    {
        private Context db = new Context();

        // GET: Fundoes
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var fundoes = from c in db.Fundoes
                          select c;
            fundoes = fundoes.Where(c => c.UserID.Contains(id));
            return View(fundoes.ToList());
        }

        // GET: Fundoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fundo fundo = db.Fundoes.Find(id);
            if (fundo == null)
            {
                return HttpNotFound();
            }
            return View(fundo);
        }

        // GET: Fundoes/Create
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

        // POST: Fundoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FundoID,InstituicaoId,Fundo_Escolhido,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Fundo fundo)
        {
            if (ModelState.IsValid)
            {
                db.Fundoes.Add(fundo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", fundo.InstituicaoId);
            return View(fundo);
        }

        // GET: Fundoes/Edit/5
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
            Fundo fundo = db.Fundoes.Find(id);
            if (fundo == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", fundo.InstituicaoId);
            return View(fundo);
        }

        // POST: Fundoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FundoID,InstituicaoId,Fundo_Escolhido,Aplica_por,Valor_Aplicado,Quantidade,Preco_Compra,Data_Inicio,UserID")] Fundo fundo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fundo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoId = new SelectList(db.Instituicoes, "Id", "nome", fundo.InstituicaoId);
            return View(fundo);
        }

        // GET: Fundoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fundo fundo = db.Fundoes.Find(id);
            if (fundo == null)
            {
                return HttpNotFound();
            }
            return View(fundo);
        }

        // POST: Fundoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fundo fundo = db.Fundoes.Find(id);
            db.Fundoes.Remove(fundo);
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
