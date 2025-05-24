using System;
using Microsoft.EntityFrameworkCore;
using SpacefinderApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacefinderApp.Data
{
    public class BookingRepository
    {
        private readonly DatabaseContext _context;

        public BookingRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetUserBookings(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.StartTime)
                .ToListAsync();
        }

        public async Task CreateBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
}