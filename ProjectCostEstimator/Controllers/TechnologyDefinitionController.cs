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
    public class TechnologyDefinitionController : Controller
    {
        private ProjectCostEstimatorContext db = new ProjectCostEstimatorContext();

        // GET: TechnologyDefinition
        public ActionResult Index()
        {
            return View(db.TechnologyDefinitions.ToList());
        }

        // GET: TechnologyDefinition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyDefinition technologyDefinition = db.TechnologyDefinitions.Find(id);
            if (technologyDefinition == null)
            {
                return HttpNotFound();
            }
            return View(technologyDefinition);
        }

        // GET: TechnologyDefinition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnologyDefinition/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,BasePrice,ProjectPriceMultiplier,TechnologyKind")] TechnologyDefinition technologyDefinition)
        {
            if (ModelState.IsValid)
            {
                db.TechnologyDefinitions.Add(technologyDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologyDefinition);
        }

        // GET: TechnologyDefinition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyDefinition technologyDefinition = db.TechnologyDefinitions.Find(id);
            if (technologyDefinition == null)
            {
                return HttpNotFound();
            }
            return View(technologyDefinition);
        }

        // POST: TechnologyDefinition/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,BasePrice,ProjectPriceMultiplier,TechnologyKind")] TechnologyDefinition technologyDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologyDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologyDefinition);
        }

        // GET: TechnologyDefinition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyDefinition technologyDefinition = db.TechnologyDefinitions.Find(id);
            if (technologyDefinition == null)
            {
                return HttpNotFound();
            }
            return View(technologyDefinition);
        }

        // POST: TechnologyDefinition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyDefinition technologyDefinition = db.TechnologyDefinitions.Find(id);
            db.TechnologyDefinitions.Remove(technologyDefinition);
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
