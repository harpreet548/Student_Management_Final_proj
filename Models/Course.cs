using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_Final_proj.Models
{
    public class Course
    {
        public int Id { get; set; }


        public string CourseName { get; set; }


        public string CourseCode {

            get {

                return "ABC-" + CourseName + "-" + Id;
            }
        
        }


        public int TotalCredits { get; set; }
    }
}
