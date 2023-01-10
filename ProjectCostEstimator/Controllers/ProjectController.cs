using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ProjectCostEstimator.Models;

namespace ProjectCostEstimator.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private ProjectCostEstimatorContext db = new ProjectCostEstimatorContext();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = project.ID });
            }

            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = project.ID });
            }
            return View(project);
        }

        // GET: Project/AddProjectTask/5
        public ActionResult AddProjectTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddProjectTaskViewModel viewModel = new AddProjectTaskViewModel();
            viewModel.Definitions = db.ProjectTaskDefinitions.ToList();
            viewModel.ProjectID = (int) id;
           
            return View(viewModel);
        }

        // POST: Project/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProjectTask([Bind(Include = "WorkingTime, ProjectTaskDefinitionID, ProjectID")] AddProjectTaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectTaskDefinition taskDefinition = db.ProjectTaskDefinitions.Find(viewModel.ProjectTaskDefinitionID);
                Project project = db.Projects.Find(viewModel.ProjectID);
                if (taskDefinition == null || project == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProjectTask projectTask = new ProjectTask();
                projectTask.ProjectTaskDefinition = taskDefinition;
                projectTask.WorkingTime = viewModel.WorkingTime;
                projectTask.UsedPricePerHour = taskDefinition.CostPerHour;
                projectTask.CalculatedCost = projectTask.UsedPricePerHour * projectTask.WorkingTime;
                project.Tasks.Add(projectTask);
                db.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = viewModel.ProjectID });
            }

            viewModel.Definitions = db.ProjectTaskDefinitions.ToList();
            return View(viewModel);
        }

        public ActionResult AddTechnology(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddTechnologyViewModel viewModel = new AddTechnologyViewModel();
            viewModel.Definitions = db.TechnologyDefinitions.ToList();
            viewModel.ProjectID = (int)id;

            return View(viewModel);
        }

        // POST: Project/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTechnology([Bind(Include = "TechnologyDefinitionID, ProjectID")] AddTechnologyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TechnologyDefinition technologyDefinition = db.TechnologyDefinitions.Find(viewModel.TechnologyDefinitionID);
                Project project = db.Projects.Find(viewModel.ProjectID);
                if (technologyDefinition == null || project == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Technology technology = new Technology();
                technology.TechnologyDefinition = technologyDefinition;
                technology.UsedBasePrice = technologyDefinition.BasePrice;
                technology.UsedPriceMultiplier = technologyDefinition.ProjectPriceMultiplier;
                project.Technologies.Add(technology);
                db.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = viewModel.ProjectID });
            }

            viewModel.Definitions = db.TechnologyDefinitions.ToList();
            return View(viewModel);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
