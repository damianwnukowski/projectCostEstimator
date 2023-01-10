using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectCostEstimator.Models;

namespace ProjectCostEstimator.Controllers
{
    [Authorize]
    public class ProjectTaskDefinitionController : Controller
    {
        private ProjectCostEstimatorContext db = new ProjectCostEstimatorContext();

        // GET: ProjectTaskDefinition
        public ActionResult Index()
        {
            return View(db.ProjectTaskDefinitions.ToList());
        }

        // GET: ProjectTaskDefinition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskDefinition projectTaskDefinition = db.ProjectTaskDefinitions.Find(id);
            if (projectTaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(projectTaskDefinition);
        }

        // GET: ProjectTaskDefinition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectTaskDefinition/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,CostPerHour")] ProjectTaskDefinition projectTaskDefinition)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTaskDefinitions.Add(projectTaskDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectTaskDefinition);
        }

        // GET: ProjectTaskDefinition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskDefinition projectTaskDefinition = db.ProjectTaskDefinitions.Find(id);
            if (projectTaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(projectTaskDefinition);
        }

        // POST: ProjectTaskDefinition/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,CostPerHour")] ProjectTaskDefinition projectTaskDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTaskDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectTaskDefinition);
        }

        // GET: ProjectTaskDefinition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTaskDefinition projectTaskDefinition = db.ProjectTaskDefinitions.Find(id);
            if (projectTaskDefinition == null)
            {
                return HttpNotFound();
            }
            return View(projectTaskDefinition);
        }

        // POST: ProjectTaskDefinition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTaskDefinition projectTaskDefinition = db.ProjectTaskDefinitions.Find(id);
            db.ProjectTaskDefinitions.Remove(projectTaskDefinition);
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
