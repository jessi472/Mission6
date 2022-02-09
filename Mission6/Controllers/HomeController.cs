using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {

        private NewTaskContext taskContext { get; set; }

        public HomeController( NewTaskContext someTask)
        {
            taskContext = someTask;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewTasks()
        {
            // View Quadrants of tasks
            var tasks = taskContext.TaskResp
                .Include(x => x.Category)
                //.Where(x => x.Completed == false)
                //.OrderBy (x => x.Value)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult NewTask()
        {
            //Add new task
            ViewBag.Category = taskContext.CategoryResp.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewTask(CoveyForm tr)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(tr);
                taskContext.SaveChanges();

                //Do we want a confirmation page?
                //return View("Confirmation");
                return View();

            }

            else
            {
                ViewBag.Category = taskContext.CategoryResp.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Category = taskContext.CategoryResp.ToList();
            var task = taskContext.TaskResp.Single(x  => x.TaskId == taskid);
            return View("NewTask", task);
        }

        [HttpPost]
        public IActionResult EditTask (CoveyForm tr)
        {
            taskContext.Update(tr);
            taskContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = taskContext.TaskResp.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete (CoveyForm tr)
        {
            taskContext.TaskResp.Remove(tr);
            taskContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

    }
}

