using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
//using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name of Employer is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Employer Name should be between 2-50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Location of Employer is required.")]
        [StringLength(50, ErrorMessage = "Location is over 50 characters.")]
        public string? Location { get; set; }
        public AddEmployerViewModel() { }
    }
}
