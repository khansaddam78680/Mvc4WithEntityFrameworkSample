using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentDetails.Models;
using StudentDetails.ViewModels;

namespace StudentDetails.Controllers
{
    [HandleError]
    public class StudentController : Controller
    {
        private StudentDBContext _db;
        public StudentController()
        {
            this._db = new StudentDBContext();
        }
        //
        // GET: /Student/
        [ActionName("StudentsDetail")]
        public ActionResult Index()
        {
            List<StudentDetailViewModel> studentDetails = new List<StudentDetailViewModel>();
            var data = _db.StudentDetails;
            foreach (var item in data)
            {
                double totalmarks = 300;
                double obtainedmarks = item.English + item.Science + item.Computer;
                string grade = "";
                double percent;
                percent = (obtainedmarks * 100) / totalmarks;
                percent = Math.Round(percent, 2);
                if (percent >= 35 && percent < 40)
                {
                    grade = "Pass Class";
                }
                else if (percent >= 40 && percent < 60)
                {
                    grade = "Second Class";
                }
                else if (percent >= 60 && percent < 70)
                {
                    grade = "First Class";
                }
                else if (percent >= 70 && percent <= 100)
                {
                    grade = "Distinction";
                }

                studentDetails.Add(new StudentDetailViewModel
                {
                    StudentName = item.StudentName,
                    English = item.English,
                    Science = item.Science,
                    Computer = item.Computer,
                    Year = item.Year,
                    Percentage = (decimal)percent,
                    Grade = grade
                });
            }
            return View(studentDetails);
        }

        [HttpGet, ActionName("NewStudentData")]
        public ActionResult InsertNewStudentDetail()
        {
            return View();
        }

        [HttpPost, ActionName("NewStudentData")]
        public ActionResult InsertNewStudentDetail(StudentDetail studentDetails)
        {
            if (ModelState.IsValid)
            {
                _db.StudentDetails.AddObject(studentDetails);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
