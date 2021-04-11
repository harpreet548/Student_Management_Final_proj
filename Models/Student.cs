using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_Final_proj.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StudentRegistrationId
        {
            get {

                return "ABC00000" + Id;
            
            }
        
        }

        public string Email { get; set; }

        public string Phone { get; set; }

        [NotMapped]
        public string Password { get; set; }

    }
}
