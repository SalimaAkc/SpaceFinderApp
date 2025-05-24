using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Model
{
    internal class Room
    {
        public int ID { get; set; }
        public required string RoomNumber { get; set; }
        public bool Status { get; set; }
        public int RoomsUpdated { get; set; }
    }
}
