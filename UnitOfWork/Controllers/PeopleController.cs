using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Models;
using UnitOfWork.UoW;

namespace UnitOfWork.Controllers
{
    /// <summary>
    /// People Controller
    /// </summary>
    public class PeopleController : Controller
    {
        /// <summary>
        /// Generic Unit Of Work class that will be injected
        /// </summary>
        private readonly GenericUoW UoW2 = null;

        public PeopleController (GenericUoW UoW2)
        {
            this.UoW2 = UoW2;
        }

        // GET: People
        public ActionResult Index()
        {
            var people = UoW2.Repository<person>().GetAll().ToList();
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = UoW2.Repository<person>().Get(c => c.id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.id_job = new SelectList(UoW2.Repository<job>().GetAll().ToList(), "id", "name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,sex,developer,description,id_job")] person person)
        {
            if (ModelState.IsValid)
            {
                UoW2.Repository<person>().Add(person);
                UoW2.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_job = new SelectList(UoW2.Repository<job>().GetAll().ToList(), "id", "name", person.id_job);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = UoW2.Repository<person>().Get(c => c.id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_job = new SelectList(UoW2.Repository<job>().GetAll().ToList(), "id", "name", person.id_job);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sex,developer,description,id_job")] person person)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    UoW2.Repository<person>().Attach(person);
                    UoW2.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            ViewBag.id_job = new SelectList(UoW2.Repository<job>().GetAll().ToList(), "id", "name", person.id_job);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = UoW2.Repository<person>().Get(c => c.id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            person contact = UoW2.Repository<person>().Get(c => c.id == id);
            UoW2.Repository<person>().Delete(contact);
            UoW2.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
