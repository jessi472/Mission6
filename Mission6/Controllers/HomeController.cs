using Microsoft.AspNetCore.Mvc;
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
            var tasks = taskContext.Responses
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
            ViewBag.Category = taskContext.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewTask(TaskResponse tr)
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
                ViewBag.Category = taskContext.Category.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Category = taskContext.Category.ToList();
            var task = taskContext.Responses.Single(x  => x.TaskId == taskid);
            return View("NewTask", task);
        }

        [HttpPost]
        public IActionResult EditTask (TaskResponse tr)
        {
            taskContext.Update(tr);
            taskContext.SaveChanges();
            return RedirectToAction("ViewTasks")
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = taskContext.Responses.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete (TaskResponse tr)
        {
            taskContext.Responses.Remove(tr);
            taskContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

    }
}

