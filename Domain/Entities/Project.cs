using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountatApp.Domain.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int WorkerId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Hourly Wage")]
        public int HourlyWage { get; set; }
        [Display(Name = "Working Hours Normal")]
        public int WorkingHoursNormal { get; set; }
        [Display(Name = "Working Hours Overtime")]
        [Range(0,30)]
        public int WorkingHoursOvertime { get; set; }
        [Display(Name = "Working Hours Nigh")]
        public int WorkingHoursNight { get; set; }
        public Worker Worker { get; set; }

    }
}
