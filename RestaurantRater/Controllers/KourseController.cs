using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Details(int id)
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

        //for the base view, prior to posting the update to the controller
        public ActionResult Edit(int id)
        {
            var context = new KourseDbContext();
            var entity = context.Kourses.Find(id);
            if (entity != null)
            {
                return View(entity);
            }
            //return 404 page
            return Redirect("/kourse");
        }

        //the actual edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kourse model)
        {

            ////if(model.KourseId != id)
            //{
            //    return Redirect("/kourse");
            //}
            var context = new KourseDbContext();
            var entity = context.Kourses.Find(id);
            if (entity != null)
            {
                //do the update
                return Redirect("/kourse");
            }
            //return 404 page
            return View(model);
        }
    }
}