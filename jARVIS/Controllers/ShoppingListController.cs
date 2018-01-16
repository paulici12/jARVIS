using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jARVIS.Models;

namespace jARVIS.Controllers
{
    public class ShoppingListController : Controller
    {
        private ShoppingListDBContext db = new ShoppingListDBContext();

        // GET: ShoppingList
        public ActionResult Index()
        {
            return View(db.ShoppingList.ToList());
        }

        // GET: ShoppingList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingList.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Timestamp,ItemName,Amount,Description,Completed")] ShoppingListModel shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingList.Add(shoppingListModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListModel);
        }

        // GET: ShoppingList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingList.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Timestamp,ItemName,Amount,Description,Completed")] ShoppingListModel shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListModel);
        }

        // GET: ShoppingList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingList.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListModel shoppingListModel = db.ShoppingList.Find(id);
            db.ShoppingList.Remove(shoppingListModel);
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
