using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagementSystem.Models;
using Utility;

namespace AssetManagementSystem.Controllers
{
    public class LocationsController : Controller
    {
        private AssetManagementSystemContext db = new AssetManagementSystemContext();

        // Add
        public ActionResult Add([System.Web.Http.FromBody] Location location)
        {
            if (location == null || location.Name == null)
            {
                return new EmptyResult();
            }

            if (ModelState.IsValid)
            {
                db.Locations.Add(location); // add the user to db

                int numChanges = 0; // number of changes made to the db
                try
                {
                    numChanges = db.SaveChanges();  // try to save changes
                }
                catch (Exception e)
                {
                    // something blew up on the save
                    return Json(new Msg { Result = "Error", Message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
                }

                // I think we're successful
                return Json(new Msg { Result = "Success", Message = $"Location.Add(): {numChanges} record(s) changed." }, JsonRequestBehavior.AllowGet);
            }

            // modelstate not valid
            return Json(new Msg { Result = "Error", Message = "Location.Add(): ModelState invalid" }, JsonRequestBehavior.AllowGet); ;
        }

        // Change
        public ActionResult Change([System.Web.Http.FromBody] Location location)
        {
            // do we have a valid location?
            if (location == null)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Change(): location cannot be null." }, JsonRequestBehavior.AllowGet);
            }

            // find the same location in the db by Location.Id
            Location dbLocation = null;
            try
            {
                dbLocation = db.Locations.Find(location.Id);
            }
            catch (Exception e)
            {
                return Json(new Msg { Result = "Error", Message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
            }

            if (dbLocation == null)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Change(): invalid Location.Id." }, JsonRequestBehavior.AllowGet);
            }

            dbLocation.Copy(location);
            if (ModelState.IsValid)
            {
                int numChanges = 0;
                try
                {
                    numChanges = db.SaveChanges();
                }
                catch (Exception e)
                {
                    return Json(new Msg { Result = "Error", Message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
                }

                return Json(new Msg { Result = "Success", Message = $"Location.Change(): {numChanges} record(s) changed." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "Location.Change(): ModelState invalid." }, JsonRequestBehavior.AllowGet);
        }

        // Get
        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Get(): Location.Id null or zero." }, JsonRequestBehavior.AllowGet);
            }

            Location location = db.Locations.Find(id);

            if (location == null)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Get(): Location.Id invalid." }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult { Data = location };
        }

        // List
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Locations.ToList() };
        }

        // Remove
        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Remove(): Location.Id null or zero." }, JsonRequestBehavior.AllowGet);
            }

            Location location = db.Locations.Find(id);

            if (location == null)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Remove(): Location.Id invalid." }, JsonRequestBehavior.AllowGet);
            }

            int numChanges = 0;
            try
            {
                db.Locations.Remove(location);
                numChanges = db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new Msg { Result = "Error", Message = "Location.Remove(): " + e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Success", Message = $"Location.Remove(): {numChanges} record(s) changed." }, JsonRequestBehavior.AllowGet);
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
