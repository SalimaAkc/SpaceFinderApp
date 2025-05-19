using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string RNumber { get; set; }
        public string SchoolEmail { get; set; }
        public string PasswordHash { get; set; }
        public Boolean IsTeacher { get; set; }
        public string ResetToken { get; set; }
        public DateTime ResetTokenExpiry { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
