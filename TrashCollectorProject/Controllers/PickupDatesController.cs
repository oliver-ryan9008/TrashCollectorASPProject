using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class PickupDatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickupDates
        public ActionResult Index()
        {
            return View(db.PickupDates.ToList());
        }

        // GET: PickupDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupDate pickupDate = db.PickupDates.Find(id);
            if (pickupDate == null)
            {
                return HttpNotFound();
            }
            return View(pickupDate);
        }

        // GET: PickupDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PickupDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,PickupDates")] PickupDate pickupDate, Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.PickupDates.Add(customer.OneTimePickupDate().ToString());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pickupDate);
        }

        // GET: PickupDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupDate pickupDate = db.PickupDates.Find(id);
            if (pickupDate == null)
            {
                return HttpNotFound();
            }
            return View(pickupDate);
        }

        // POST: PickupDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,PickupDates")] PickupDate pickupDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickupDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pickupDate);
        }

        // GET: PickupDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupDate pickupDate = db.PickupDates.Find(id);
            if (pickupDate == null)
            {
                return HttpNotFound();
            }
            return View(pickupDate);
        }

        // POST: PickupDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickupDate pickupDate = db.PickupDates.Find(id);
            db.PickupDates.Remove(pickupDate);
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
