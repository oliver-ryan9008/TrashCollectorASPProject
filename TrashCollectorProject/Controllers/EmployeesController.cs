﻿using System;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public void GetTodayDayOfWeek()
        {
            string todayDayOfWeek = DateTime.Now.DayOfWeek.ToString();
            string date = DateTime.Now.ToString();
        }

        // GET: Pickups
        public ActionResult EmployeeTodayPickups(Employee employee, Customer customer)
        {
            var todayDayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var todayDate = DateTime.Now.Date;
            var customersMatchingZip = (from p in db.Customers where customer.ZipCode == employee.ZipCode select p).ToList();
            
            if (customersMatchingZip.Count() == 0)
            {
                return View();
            }
            else 
            {
                var checkTodayPickups = db.Customers.Where(c => c.OneTimePickupDate == todayDate || c.WeeklyPickupDay == todayDayOfWeek).ToList();
                if (checkTodayPickups.Count() == 0)
                {
                    return View();
                }
                else
                {
                    return View(checkTodayPickups);
                }
            }
        }

        public int? ChargeCustomer(Customer customer)
        {
            
            customer.MoneyOwed = customer.MoneyOwed + 100;
            var money = customer.MoneyOwed;

            return money;
        }

        public ActionResult ConfirmPickup(Customer customer, Employee employee)
        {
            var currentCustomerPickup = customer.CustomerId;
            var findCurrentCustomer = (from c in db.Customers where c.CustomerId == currentCustomerPickup select c).First();
            var moneyOwed = ChargeCustomer(customer);
            
            findCurrentCustomer.MoneyOwed = moneyOwed;
            findCurrentCustomer.MoneyOwed = customer.MoneyOwed;
            
                
            db.SaveChanges();
            return View("EmployeeTodayPickups");
            
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmailAddress,UserName,Password,FullName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("EmployeeTodayPickups");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmailAddress,UserName,Password,FullName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeTodayPickups");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
