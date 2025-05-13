using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    class Schedules
    {
        public int ScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayOfWeek { get; set; }

        public string CourseName { get; set; }


    }
}
