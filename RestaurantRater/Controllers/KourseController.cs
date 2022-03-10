using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class KourseController : Controller
    {
        private KourseDbContext _ctx = new KourseDbContext();

        // GET: Kourse/Index
        public ActionResult Index()
        {
            var context = new KourseDbContext();
            var query = context.Kourses.ToArray();
            ViewData["Error"] = string.Empty;
            // return View(_ctx.Kourses.ToList();
            return View(query);
        }

        // GET: Kourse/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Kourse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kourse model)
        {
            if (ModelState.IsValid)
            {
                var context = new KourseDbContext();
                context.Kourses.Add(model);
                if (context.SaveChanges() == 1)
                {
                    //Should show a successs page
                    return Redirect("/Kourse");
                    //return RedirectToAction("Index");
                }
                ViewData["Error"] = "Couldn't create that course.";
                return View(model);
            }
            else
            {
                ViewData["Error"] = "Couldn't create that course.";
                return View(model);
            }
        }

        //GET: /kourse/Details/[id]
        public ActionResult Details(int? id)
        {
            var context = new KourseDbContext();
            var entity = context.Kourses.Find(id);
            if(entity != null)
            {
                return View(entity);
            }
            //return 404 page
            return Redirect("/kourse");
        }

        //GET: /Kourse/Edit/{id}
        //for the base view, prior to posting the update to the controller
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var context = new KourseDbContext();
            var kourse = context.Kourses.Find(id);
            if (kourse != null)
            {
                return View(kourse);
            }
            //return 404 
            return HttpNotFound();
        }

        //POST: /kourse/edit{id}
        //the actual edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kourse model)
        {
            var context = new KourseDbContext();

            if(model.KourseId != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(!ModelState.IsValid)
            {
                ViewData["Error"] = "Couldn't update that course.";
                return View(model);
            }
            else
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            //var entity = context.Kourses.Find(id);
            //if (entity != null)
            //{
            //    //do the update
            //    return Redirect("/kourse");
            //}
            ////return 404 page
            //return View(model);
        }

        //GET: /Kourse/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int? kourseId)
        {
            if(kourseId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var context = new KourseDbContext();
            Kourse kourseToDelete = context.Kourses.Find(kourseId);
            if (kourseToDelete == null)
            {
                return HttpNotFound();
            }
            return View(kourseToDelete);
        }

        //POST: / Kourse/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int kourseId)
        {
            var context = new KourseDbContext();
            Kourse kourseToDelete = context.Kourses.Find(kourseId);
            context.Kourses.Remove(kourseToDelete);
            int wasSuccess = context.SaveChanges();
            if (wasSuccess == 1)
            {
                return Redirect("/kourse");
            }
            else
            {
                ViewData["Error"] = "Couldn't delete that course.";
                return View();
            }
        }
    }
}