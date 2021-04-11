using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management_Final_proj.Models;

namespace Student_Management_Final_proj.Models
{
    public class Student_Management_Data_Context : DbContext
    {
        public Student_Management_Data_Context (DbContextOptions<Student_Management_Data_Context> options)
            : base(options)
        {
        }

        public DbSet<Student_Management_Final_proj.Models.Course> Course { get; set; }

        public DbSet<Student_Management_Final_proj.Models.Enrolment> Enrolment { get; set; }

        public DbSet<Student_Management_Final_proj.Models.Student> Student { get; set; }
    }
}
