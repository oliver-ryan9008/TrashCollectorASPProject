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
    public class TrashCollectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectors
        public ActionResult Index()
        {
            return View(db.TrashCollectors.ToList());
        }

        // GET: TrashCollectors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollector trashCollector = db.TrashCollectors.Find(id);
            if (trashCollector == null)
            {
                return HttpNotFound();
            }
            return View(trashCollector);
        }

        // GET: TrashCollectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrashCollectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailAddress")] TrashCollector trashCollector)
        {
            if (ModelState.IsValid)
            {
                db.TrashCollectors.Add(trashCollector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trashCollector);
        }

        // GET: TrashCollectors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollector trashCollector = db.TrashCollectors.Find(id);
            if (trashCollector == null)
            {
                return HttpNotFound();
            }
            return View(trashCollector);
        }

        // POST: TrashCollectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailAddress")] TrashCollector trashCollector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trashCollector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trashCollector);
        }

        // GET: TrashCollectors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollector trashCollector = db.TrashCollectors.Find(id);
            if (trashCollector == null)
            {
                return HttpNotFound();
            }
            return View(trashCollector);
        }

        // POST: TrashCollectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TrashCollector trashCollector = db.TrashCollectors.Find(id);
            db.TrashCollectors.Remove(trashCollector);
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
