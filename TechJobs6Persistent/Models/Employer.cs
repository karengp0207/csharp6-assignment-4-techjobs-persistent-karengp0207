using System;

namespace TechJobs6Persistent.Models
{
    public class Employer
    {
        public string? Name { get; set; }
        public string? Location { get; set; }

        public int? Id { get; set; }
        public List<Job>? Jobs { get; set; }
                
        public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public Employer() { }
        
    }
}
