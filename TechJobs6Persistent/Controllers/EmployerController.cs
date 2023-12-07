using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller  /*from Ch19 Identity and Authorization*/
    {
        private JobDbContext context;  //task2, Controllers #1 set up a private JobDbContext , adding the data store

        public EmployerController(JobDbContext dbContext) //task2, Controllers #1 pass JobDbContext into the constructor
        {
            context = dbContext;
        }


        // GET: /<controller>/
        //[HttpGet]
        public IActionResult Index() /*from Ch17, Working with Data Stores*/
        {
            List<Employer>employers = context.Employers.ToList();
            return View(employers);
        }
        
        //[HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();     //create an instance of AddEmployerViewModel
                                                                                        //and pass into the View() return method.
            return View(addEmployerViewModel);              
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)  /*property to check if submitted data is valid based on AddEmployerViewModel.cs*/
            {
                Employer employer = new Employer(addEmployerViewModel.Name,addEmployerViewModel.Location)
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
             return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            var employer = context.Employers.Find(id);
            if (employer == null)
            {
                return NotFound();
            }
            return View(employer);
        }

    }
}

