using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Name of Job is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Job Name should be between 2-50 characters.")]
        public string? JobName { get; set; }

        [Required(ErrorMessage = "Job ID is required.")]
        public int? EmployerId { get; set; }
        public List<SelectListItem>? ListofEmployers { get; set; } = new List<SelectListItem>();
        //public List<Skill> Skills { get; set; }

        public AddJobViewModel() { }
        public AddJobViewModel(List<Employer> possibleEmployers)
        {
            //ListofEmployers = new List<SelectListItem>();
            //Skills = new List<Skill> { };

            foreach(var employer in possibleEmployers)
            {
                ListofEmployers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name,
                });
            }
        }
    }
}