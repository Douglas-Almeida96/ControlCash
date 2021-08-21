using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ControlCash.Models;
using Microsoft.AspNet.Identity;

namespace ControlCash.Controllers
{
    [Authorize]
    public class GastoesController : Controller
    {
        private Context db = new Context();

        // GET: Gastoes
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var gastoes = from g in db.Gastoes
                          select g;
            gastoes = gastoes.Where(g => g.UserID.Contains(id));
            return View(gastoes.ToList());
        }

        // GET: Gastoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // GET: Gastoes/Create
        public ActionResult Create()
        {
            var id = User.Identity.GetUserId();
            var cartao = from c in db.Cartaos select c;
            cartao = cartao.Where(c => c.UserID.Contains(id));

            var renda = from r in db.RendaExtras select r;
            renda = renda.Where(r => r.UserID.Contains(id));

            ViewBag.CartaoId = new SelectList(cartao, "Id", "Nome");
            ViewBag.RendaExtraId = new SelectList(renda, "Id", "Descricao");
            ViewBag.TipoConsumoId = new SelectList(db.TipoConsumoes, "Id", "Nome");
            return View();
        }

        // POST: Gastoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CartaoId,RendaExtraId,Nparcelas,ValorTotal,TipoConsumoId,Date,UserID")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Gastoes.Add(gasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var idUser = User.Identity.GetUserId();

            var cartao = from c in db.Cartaos select c;
            cartao = cartao.Where(c => c.UserID.Contains(idUser));

            var renda = from r in db.RendaExtras select r;
            renda = renda.Where(r => r.UserID.Contains(idUser));

            ViewBag.CartaoId = new SelectList(cartao, "Id", "Nome");
            ViewBag.RendaExtraId = new SelectList(renda, "Id", "Descricao"); 
            ViewBag.TipoConsumoId = new SelectList(db.TipoConsumoes, "Id", "Nome", gasto.TipoConsumoId);
            return View(gasto);
        }

        // GET: Gastoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }

            var idUser = User.Identity.GetUserId();

            var cartao = from c in db.Cartaos select c;
            cartao = cartao.Where(c => c.UserID.Contains(idUser));

            var renda = from r in db.RendaExtras select r;
            renda = renda.Where(r => r.UserID.Contains(idUser));

            ViewBag.CartaoId = new SelectList(cartao, "Id", "Nome", gasto.CartaoId);
            ViewBag.RendaExtraId = new SelectList(renda, "Id", "Descricao", gasto.RendaExtraId); 
            ViewBag.TipoConsumoId = new SelectList(db.TipoConsumoes, "Id", "Nome", gasto.TipoConsumoId);
            return View(gasto);
        }

        // POST: Gastoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CartaoId,RendaExtraId,Nparcelas,ValorTotal,TipoConsumoId,Date,UserID")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var idUser = User.Identity.GetUserId();

            var cartao = from c in db.Cartaos select c;
            cartao = cartao.Where(c => c.UserID.Contains(idUser));

            var renda = from r in db.RendaExtras select r;
            renda = renda.Where(r => r.UserID.Contains(idUser));

            ViewBag.CartaoId = new SelectList(cartao, "Id", "Nome", gasto.CartaoId);
            ViewBag.RendaExtraId = new SelectList(renda, "Id", "Descricao", gasto.RendaExtraId); 
            ViewBag.TipoConsumoId = new SelectList(db.TipoConsumoes, "Id", "Nome", gasto.TipoConsumoId);
            return View(gasto);
        }

        // GET: Gastoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // POST: Gastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gasto gasto = db.Gastoes.Find(id);
            db.Gastoes.Remove(gasto);
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
