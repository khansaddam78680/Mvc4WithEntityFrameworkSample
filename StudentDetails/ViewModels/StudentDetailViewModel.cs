using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.ViewModels
{
    public class StudentDetailViewModel
    {
        [Display(Name="Student Name")]
        public string StudentName { get; set; }
        public int English { get; set; }
        public int Science { get; set; }
        public int Computer { get; set; }
        public int Year { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set; }
    }
}