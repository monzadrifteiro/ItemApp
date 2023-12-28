using Modelo;
using Servico;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebAppItens.Controllers
{
    public class ItemController : Controller
    {
        private ItemServico itemServico = new ItemServico();
        private ActionResult ObterVisaoItemPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemServico.ObterItemPorId((long)id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        private ActionResult GravarItem(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    itemServico.GravarItem(item);
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch
            {
                return View(item);
            }
        }

        // GET: Index
        public ActionResult Index()
        {
            return View(itemServico.ObterItensClassificadosPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            return GravarItem(item);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoItemPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            return GravarItem(item);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoItemPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoItemPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Item item = itemServico.EliminarItemPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}