using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Services
{
    public class ValidationService
    {
        public bool IsSchoolEmail(string email)
        {
            var validDomains = new[] { "@student.thomasmore.be", "@teachers.yourschool.edu" };
            return validDomains.Any(d => email.EndsWith(d, StringComparison.OrdinalIgnoreCase));
        }
    }
}