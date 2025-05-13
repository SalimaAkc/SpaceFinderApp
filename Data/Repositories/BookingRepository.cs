using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SpacefinderApp.Data.Models;
using System.Collections.Generic;

namespace SpacefinderApp.Data.Repositories
{
    public class BookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Bookings> GetAllBookings()
        {
            var bookings = new List<Bookings>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM bookings", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Bookings
                        {
                            BookingID = reader.GetInt32("booking_id"),
                            UserID = reader.GetInt32("user_id"),
                            StartTime = reader.GetDateTime("start_time"),
                            EndTime = reader.GetDateTime("end_time"),
                            Status = reader.GetBoolean("status"),
                            PeopleAmount = reader.GetInt32("people_amount"),
                            CreatedAt = reader.GetDateTime("created_at")
                        });
                    }
                }
            }
            return bookings;
        }

        public bool CreateBooking(Bookings newBooking)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(
                    @"INSERT INTO bookings 
                     (user_id, start_time, end_time, status, people_amount, created_at)
                     VALUES (@UserId, @StartTime, @EndTime, @Status, @PeopleAmount, @CreatedAt)", connection);

                command.Parameters.AddWithValue("@UserId", newBooking.UserID);
                command.Parameters.AddWithValue("@StartTime", newBooking.StartTime);
                command.Parameters.AddWithValue("@EndTime", newBooking.EndTime);
                command.Parameters.AddWithValue("@Status", newBooking.Status);
                command.Parameters.AddWithValue("@PeopleAmount", newBooking.PeopleAmount);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
