using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FourSeasonsWebShop.Models;

namespace FourSeasonsWebShop.Controllers
{
    public class Items1Controller : Controller
    {
        private FourSeasonsEntities fe = new FourSeasonsEntities();

       
        public ActionResult Index()
        {
            var items = fe.Items.Include(i => i.Category).Include(i => i.Producer);
            return View(items.ToList());
        }

       //Anvendes ikke
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = fe.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // Create
       
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(fe.Categories, "CategoryId", "Name");
            ViewBag.ProduceId = new SelectList(fe.Producers, "ProducerId", "Name");
            return View();
        }

        // POST: Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CategoryId,ProduceId,Title,Price,ItemArtUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                fe.Items.Add(item);
                fe.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(fe.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProduceId = new SelectList(fe.Producers, "ProducerId", "Name", item.ProduceId);
            return View(item);
        }

        // Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = fe.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(fe.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProduceId = new SelectList(fe.Producers, "ProducerId", "Name", item.ProduceId);
            return View(item);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CategoryId,ProduceId,Title,Price,ItemArtUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                fe.Entry(item).State = EntityState.Modified;
                fe.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(fe.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.ProduceId = new SelectList(fe.Producers, "ProducerId", "Name", item.ProduceId);
            return View(item);
        }

        //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = fe.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = fe.Items.Find(id);
            fe.Items.Remove(item);
            fe.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fe.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
