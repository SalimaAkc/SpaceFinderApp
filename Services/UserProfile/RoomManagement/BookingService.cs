using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacefinderApp.Data.Models;
using SpacefinderApp.Data.Repositories;

namespace SpacefinderApp.Services
{
    public class BookingService
    {
        private readonly BookingRepository _repository;

        public BookingService(string connectionString)
        {
            _repository = new BookingRepository(connectionString);
        }

        public List<Bookings> GetUserBookings(int userId)
        {
            return _repository.GetAllBookings()
                .Where(b => b.UserID == userId)
                .ToList();
        }

        public bool MakeBooking(Bookings booking)
        {
            // Add validation logic here
            if (booking.StartTime >= booking.EndTime)
                return false;

            return _repository.CreateBooking(booking);
        }
    }
}
