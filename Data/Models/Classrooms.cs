using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    class Classrooms
    {
        public int ClassroomID { get; set; }
        public string ClassroomNumber { get; set; }
        public int Capacity { get; set; }
        public List<Classroomfeatures> Features { get; set; } = new List<Classroomfeatures>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();



    }
}
