using FYPTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPTest.Controllers
{
    public class HomeController : Controller
    {
        private msdb1740Entities db = new msdb1740Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dropdown()
        {
            ViewBag.Message = "Your dropdown page.";

            return View(db.testDBs.ToList());
        }
       
        public JsonResult Drop(string name)
        {
            List<testDB> people = new List<testDB>();
            var query = from a in db.testDBs
                        where a.County.Contains(name)
                        select a;
            //var item = query.FirstOrDefault();
            //if (item != null){
                foreach(var q in query){
                    people.Add(new testDB
                    {
                        Surname = q.Surname,
                        Forename = q.Forename,
                        TownlandStreet = q.TownlandStreet,
                        DED = q.DED,
                        County = q.County,
                        Age = q.Age,
                        Sex = q.Sex,
                        Birthplace = q.Birthplace,
                        Occupation = q.Occupation,
                        Religion = q.Religion,
                        Literacy = q.Literacy,
                        IrishLanguage = q.IrishLanguage,
                        RelationToHeadOfHousehold = q.RelationToHeadOfHousehold,
                        MaritalStatus = q.MaritalStatus,
                        SpecifiedIllness = q.SpecifiedIllness,
                        Religion_ID = q.Religion_ID,
                        Lat = q.Lat,
                        Long = q.Long,
                        AddressToGeoCode = q.AddressToGeoCode,
                        HouseNo = q.HouseNo,
                        AmountInHouse = q.AmountInHouse,
                        OriginalCensusForm = q.OriginalCensusForm,
                        LocationType = q.LocationType
                    });

                }
                return Json(people, JsonRequestBehavior.AllowGet);
            //}
            //else
            //    return View("NotFound");  //Let's show a view about item not found
        }
    }
}