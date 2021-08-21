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
    public class QuestionariosController : Controller
    {
        private Context db = new Context();

        // GET: Questionarios
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var qt = from q in db.Questionarios
                     select q;
            qt = qt.Where(q => q.UserID.Contains(id));
            var total = 0;
            var perfil = "";
            foreach (Questionario element in qt)
            {
                total += element.Perg1;
                total += element.Perg2;
                total += element.Perg3;
                total += element.Perg4;
                total += element.Perg5;
                if (element.Perg6a)
                    total += 1;
                if (element.Perg6b)
                    total += 1;
                if (element.Perg6c)
                    total += 2;
                if (element.Perg6d)
                    total += 2;
                if (element.Perg6e)
                    total += 3;
                if (element.Perg6f)
                    total += 3;
                total += element.Perg7;
                total += element.Perg8;
            }
            if (total != 0)
            {
                if (total <= 10)
                    perfil = "Conservador";
                else if ((total > 10) && (total <= 18))
                    perfil = "Moderado";
                else if (total > 18)
                    perfil = "Arriscado";
            }
            ViewBag.perfil = perfil;
            return View(qt);
            
        }

        // GET: Questionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        // GET: Questionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestID,Perg1,Perg2,Perg3,Perg4,Perg5,Perg6a,Perg6b,Perg6c,Perg6d,Perg6e,Perg6f,Perg7,Perg8,UserID")] Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                db.Questionarios.Add(questionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionario);
        }

        // GET: Questionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        // POST: Questionarios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestID,Perg1,Perg2,Perg3,Perg4,Perg5,Perg6,Perg7,Perg8,Valor_Investido,UserID")] Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionario);
        }

        // GET: Questionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        // POST: Questionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionario questionario = db.Questionarios.Find(id);
            db.Questionarios.Remove(questionario);
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
