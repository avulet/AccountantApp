using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountatApp.Domain.Entities
{
    public class Worker
    {
        public int WorkerId { get; set; }
        [Required]
        [Display(Name = "Worker Name")]
        public string Name { get; set; }
        public double Wage { get; set; }
        public Project Project { get; set; }
    }
}
