using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class CustomersController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult DisplayMoneyOwed(int id)
        {
            var moneyOwed = (from m in db.Customers where m.CustomerId == id select m.MoneyOwed).FirstOrDefault().ToString();
            var displayMoney = "$" + moneyOwed;
            return View(displayMoney);
        }

        //public ActionResult AddAllPickupDates(Customer customer, PickupDate pickupDate)
        //{
        //    var allPickups = (from p in db.Customers where DateTime.Now <= pickupDate.PickupDates select p).ToList();
        //}

        public ActionResult ChooseNewOneTimePickup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseNewOneTimePickup([Bind(Include = "OneTimePickupDate")] Customer customer)
        {
            var userId = User.Identity.GetUserId();
            var identityToInt = userId;
            var getCustomerChoice = (from c in db.Customers where userId == c.UserId select c).First();
            getCustomerChoice.OneTimePickupDate = customer.OneTimePickupDate;
            
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,EmailAddress,UserName,Password,FullName,StreetAddress,ZipCode,WeeklyPickupDay,MoneyOwed")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.MoneyOwed = 0;
                customer.UserId = User.Identity.GetUserId();                
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,EmailAddress,UserName,Password,FullName,StreetAddress,ZipCode,WeeklyPickupDay,OneTimePickupDate,MoneyOwed")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
