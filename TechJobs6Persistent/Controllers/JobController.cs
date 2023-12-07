using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
      
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.ToList(); //=new List<Job>(JobData.GetAll());

            return View(jobs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Employer>employers = context.Employers.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers);       //List<Employer> employers = context.Employers.ToList();
            //List<Skill> skills = context.Skills.ToList();              //this method needs to contain a list of Employer objects
                                                                       //which it pulls from the Employer dbContext
                                                                       //create an instance of the AddJobViewModel which is 
                                                                       //passed the list of employer objects
            return View(addJobViewModel);                              //pass an instance of AddJobViewModel to the view
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)   //rename ProcessAddJobForm to Add and add [HttpPost]
        {
            
            if (ModelState.IsValid)
            {
                Employer employer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newJob = new Job
                {                                                    //and make sure that any validation conditions are
                                                                     //met before creating the new Job object
                    Name = addJobViewModel.JobName,
                    Employer = employer,
                    //Skills = addJobViewModel.Skills.ToList()
                };
                context.Jobs.Add(newJob);
                context.SaveChanges();

                return Redirect("/Job");
            }
            return View(addJobViewModel);
        }

            public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

