using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacefinderApp.Data;
using Microsoft.EntityFrameworkCore;
using SpacefinderApp.Model;


namespace SpacefinderApp.Services
{

    public static class EmailValidator
    {
        private const string StudentDomain = "@student.thomasmore.be";
        private const string TeacherDomain = "@staff.thomasmore.be"; 

        public static (bool IsValid, UserType UserType) ValidateSchoolEmail(string email)
        {
            if (email.EndsWith(StudentDomain, StringComparison.OrdinalIgnoreCase))
            {
                return (true, UserType.Student);
            }
            else if (email.EndsWith(TeacherDomain, StringComparison.OrdinalIgnoreCase))
            {
                return (true, UserType.Teacher);
            }
            return (false, UserType.Student); 
        }
    }
}