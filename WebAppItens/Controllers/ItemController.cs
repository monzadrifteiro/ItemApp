using Modelo;
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
        private EFContext context = new EFContext();
        // GET: Index
        public ActionResult Index()
        {
            return View(context.Itens.OrderBy(c => c.Nome));
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
            context.Itens.Add(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Itens.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Itens.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Itens.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Item item = context.Itens.Find(id);
            context.Itens.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}