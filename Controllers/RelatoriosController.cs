using ControlCash.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCash.Controllers
{
    [Authorize]
    public class RelatoriosController : Controller
    {
        Context db = new Context();

        // GET: Relatorio por mes atual
        public ActionResult Index()
        {/*apenas para tirar print*/
            /*
            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == DateTime.Today.Month  &&  l.Date.Year == DateTime.Today.Year && l.UserID == id
                         select l).ToList();*/
            var julho = 7;
            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == julho && l.Date.Year == DateTime.Today.Year && l.UserID == id
                         select l).ToList();
            return View(query);
        }
        public ActionResult GetData()
        {/*apenas para tirar print*/
            /*
            ////falta filtar pelo usuario ---
            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == DateTime.Today.Month && l.Date.Year == DateTime.Today.Year && l.UserID == id
                         group l by l.TipoConsumo into g
                         select new
                         {
                             Nome = g.Key.Nome,
                             Soma = g.Sum(l => l.ValorTotal)
                         }).ToList();*/
            var julho = 7;
            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == julho && l.Date.Year == DateTime.Today.Year && l.UserID == id
                         group l by l.TipoConsumo into g
                         select new
                         {
                             Nome = g.Key.Nome,
                             Soma = g.Sum(l => l.ValorTotal)
                         }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Carteira()
        {
            var id = User.Identity.GetUserId();
            var query = (from l in db.Acoes_BDR_FII
                         where l.UserID == id
                         select l).ToList();
            return View(query);
        }
        public ActionResult CarteiraData()
        {
            var id = User.Identity.GetUserId();
            var invest = (from l in db.Acoes_BDR_FII
                          where l.UserID == id
                          group l by l.Instituicao into g
                          select new
                          {
                              Nome = g.Key.nome,
                              Soma = g.Sum(l => l.Preco_Compra * l.Quantidade)
                          }).ToList();


            return Json(invest, JsonRequestBehavior.AllowGet);
        }
            public ActionResult Buscar(DateTime? date)
        {

            if (date != null)
            {

                GetPorData(date.Value.Date);
                return RedirectToAction("Resultado", date);

            }
            else
            {
                return View();
            }

        }

        public ActionResult GetPorData(DateTime? date)
        {

            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == date.Value.Month && l.Date.Year == DateTime.Today.Year && l.UserID == id
                         group l by l.TipoConsumo into g
                         select new
                         {
                             Nome = g.Key.Nome,
                             Soma = g.Sum(l => l.ValorTotal)
                         }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Resultado(DateTime? date)
        {
            var id = User.Identity.GetUserId();
            var query = (from l in db.Gastoes
                         where l.Date.Month == date.Value.Month && l.Date.Year == date.Value.Year && l.UserID == id
                         select l).ToList();

            return View(query);
        }
    }
}