using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UNumber { get; set; }
        public string SchoolEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool IsTeacher { get; internal set; }
        public DateTime CreatedAt { get; set; }
    }
}
