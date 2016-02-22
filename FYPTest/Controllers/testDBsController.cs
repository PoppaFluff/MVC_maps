using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYPTest.Models;

namespace FYPTest.Controllers
{
    public class testDBsController : Controller
    {
        private msdb1740Entities db = new msdb1740Entities();

        // GET: testDBs
        public ActionResult Index()
        {
            return View(db.testDBs.ToList());
        }

        // GET: testDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testDB testDB = db.testDBs.Find(id);
            if (testDB == null)
            {
                return HttpNotFound();
            }
            return View(testDB);
        }

        // GET: testDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Surname,Forename,TownlandStreet,DED,County,Age,Sex,Birthplace,Occupation,Religion,Literacy,IrishLanguage,RelationToHeadOfHousehold,MaritalStatus,SpecifiedIllness,Religion_ID,Lat,Long,AddressToGeoCode,HouseNo,AmountInHouse,OriginalCensusForm,LocationType")] testDB testDB)
        {
            if (ModelState.IsValid)
            {
                db.testDBs.Add(testDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testDB);
        }

        // GET: testDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testDB testDB = db.testDBs.Find(id);
            if (testDB == null)
            {
                return HttpNotFound();
            }
            return View(testDB);
        }

        // POST: testDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Surname,Forename,TownlandStreet,DED,County,Age,Sex,Birthplace,Occupation,Religion,Literacy,IrishLanguage,RelationToHeadOfHousehold,MaritalStatus,SpecifiedIllness,Religion_ID,Lat,Long,AddressToGeoCode,HouseNo,AmountInHouse,OriginalCensusForm,LocationType")] testDB testDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testDB);
        }

        // GET: testDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testDB testDB = db.testDBs.Find(id);
            if (testDB == null)
            {
                return HttpNotFound();
            }
            return View(testDB);
        }

        // POST: testDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            testDB testDB = db.testDBs.Find(id);
            db.testDBs.Remove(testDB);
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
