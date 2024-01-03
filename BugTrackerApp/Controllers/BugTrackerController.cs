using BugTrackerApp.DAL.Interface;
using BugTrackerApp.DAL.Repository;
using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApp.Controllers
{
    public class BugTrackerController : Controller
    {
        private readonly IBugTrackerInterface _Repository;
        public BugTrackerController(IBugTrackerInterface service)
        {
            _Repository = service;
        }
        public BugTrackerController()
        {
            // Constructor logic, if needed
        }
        // GET: BugTracker
        public ActionResult Index()
        {
            var Bugs = from work in _Repository.GetBugs()
                        select work;
            return View(Bugs);
        }

        public ViewResult Details(int id)
        {
            Bug Bug =   _Repository.GetBugByID(id);
            return View(Bug);
        }

        public ActionResult Create()
        {
            return View(new Bug());
        }

        [HttpPost]
        public ActionResult Create(Bug Bug)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.InsertBug(Bug);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Bug);
        }

        public ActionResult EditAsync(int id)
        {
            Bug Bug =  _Repository.GetBugByID(id);
            return View(Bug);
        }
        [HttpPost]
        public ActionResult Edit(Bug Bug)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.UpdateBug(Bug);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Bug);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Bug Bug =  _Repository.GetBugByID(id);
            return View(Bug);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Bug Bug =  _Repository.GetBugByID(id);
                _Repository.DeleteBug(id);
                _Repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}