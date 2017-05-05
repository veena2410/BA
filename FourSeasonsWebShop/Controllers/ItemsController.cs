//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using FourSeasonsWebShop.Models;

//namespace FourSeasonsWebShop.Controllers
//{
//    public class ItemsController : Controller
//    {
//        private FourSeasonsEntities db = new FourSeasonsEntities();

//        // GET: Items
//        [Authorize(Users = "test@fourseasons.com")] //KODE: test123;
//        public ActionResult Index()
//        {

//            var items = db.Items.Include(i => i.Category).Include(i => i.Producer);
//            return View(items.ToList());
//        }

//        // GET: Store/Item: INDEX CUSTOMER
//        public ActionResult CustomerIndex()
//        {
//            var items = db.Items.Include(i => i.Category).Include(i => i.Producer);
//            return View(items.ToList());
//        }



//        //// GET: Items/Details/5
//        //public ActionResult Details(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    Product item = db.Items.Find(id);
//        //    if (item == null)
//        //    {
//        //        return HttpNotFound();
//        //    }
//        //    return View(item);
//        //}

//        // GET: Items/Create
//        public ActionResult Create()
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            ViewBag.ProduceId = new SelectList(db.Producers, "ProducerId", "Name");
//            return View();
//        }

//        // POST: Items/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ItemId,CategoryId,ProduceId,Title,Price,ItemArtUrl")] Product item)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Items.Add(item);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
//            ViewBag.ProduceId = new SelectList(db.Producers, "ProducerId", "Name", item.ProduceId);
//            return View(item);
//        }

//        // GET: Items/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product item = db.Items.Find(id);
//            if (item == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
//            ViewBag.ProduceId = new SelectList(db.Producers, "ProducerId", "Name", item.ProduceId);
//            return View(item);
//        }

//        // POST: Items/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ItemId,CategoryId,ProduceId,Title,Price,ItemArtUrl")] Product item)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(item).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
//            ViewBag.ProduceId = new SelectList(db.Producers, "ProducerId", "Name", item.ProduceId);
//            return View(item);
//        }

//        // GET: Items/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product item = db.Items.Find(id);
//            if (item == null)
//            {
//                return HttpNotFound();
//            }
//            return View(item);
//        }

//        // POST: Items/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Product item = db.Items.Find(id);
//            db.Items.Remove(item);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
