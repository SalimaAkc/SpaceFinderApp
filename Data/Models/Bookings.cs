using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    class Bookings
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool Status { get; set; }

        public int PeopleAmount { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
