using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
/*using Mission6.Models;*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private NewTaskContext TaskContext { get; set; }

        //For some reason this needed to be private. May cause more probs
        private HomeController(NewTaskContext someTask)
        { 
            TaskContext = someTask;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewTasks()
        {
            // View Quadrants of tasks
            var tasks = TaskContext.TaskResp
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
            ViewBag.Category = TaskContext.CategoryResp.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewTask(CoveyForm tr)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Add(tr);
                TaskContext.SaveChanges();

                //Do we want a confirmation page?
                //return View("Confirmation");
                return View();

            }

            else
            {
                ViewBag.Category = TaskContext.CategoryResp.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Category = TaskContext.CategoryResp.ToList();
            var task = TaskContext.TaskResp.Single(x  => x.TaskId == taskid);
            return View("NewTask", task);
        }

        [HttpPost]
        public IActionResult EditTask (CoveyForm tr)
        {
            TaskContext.Update(tr);
            TaskContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = TaskContext.TaskResp.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete (CoveyForm tr)
        {
            TaskContext.TaskResp.Remove(tr);
            TaskContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

    }
}

