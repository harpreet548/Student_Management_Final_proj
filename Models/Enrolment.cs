using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_Final_proj.Models
{
    public class Enrolment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }


        public Course Course { get; set; }

        public Student Student { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


    }
}
