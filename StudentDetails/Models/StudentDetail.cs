using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    [MetadataType(typeof(StudentDetailMetaData))]
    public partial class StudentDetail
    {

    }
    public class StudentDetailMetaData
    {
        [Required(ErrorMessage = "Student Name is Required")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name="Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "English Marks is Required")]
        [Range(0, 100)]
        public int English { get; set; }

        [Required(ErrorMessage = "Science Marks is Required")]
        [Range(0, 100)]
        public int Science { get; set; }

        [Required(ErrorMessage = "Computer Marks is Required")]
        [Range(0, 100)]
        public int Computer { get; set; }

        [Required(ErrorMessage = "Year is Required")]
        [Range(0000, 9999)]
        public int Year { get; set; }
        //public decimal Percentage { get; set; }
        //public string Grade { get; set; }
    }
}