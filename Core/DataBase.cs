using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacefinderApp.Data.Models;
using MySqlConnector;

namespace SpacefinderApp.Data
{
    public class DataBase
    {
        
        private string connectionString = 
        "datasource = 127.0.0.1;" +
        "port = 3306;"+
        "username = root; password =;"+
        "database = spacefinder;";

        private const int StudentType = 1;
        private const int TeacherType = 2;

        private int Insert(string query)
        {
            Student student = new Student();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                int result = commandDatabase.ExecuteNonQuery();
                return (int)commandDatabase.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int InsertStudent(Student student)
        {
            string query = $"INSERT INTO users (ID, Name, RNumber, SchoolEmail, PasswordHash, IsTeacher, CreatedAt)" +
                         $"VALUES ('{student.ID}', '{student.FullName}', '{student.RNumber}', '{student.SchoolEmail}', '{student.PasswordHash}', '{student.IsTeacher}', '{student.CreatedAt}');";
            return this.Insert(query);


        }
            
        public int InsertTeacher(Teacher teacher)
        {
            string query = $"INSERT INTO users (ID, Name, UNumber, SchoolEmail, PasswordHash, IsTeacher, CreatedAt)" +
                        $"VALUES ({teacher.ID}', '{teacher.FullName}', '{teacher.UNumber}', '{teacher.SchoolEmail}', '{teacher.PasswordHash}', '{teacher.IsTeacher}', '{ teacher.CreatedAt}');";
            return this.Insert(query);

        }

        public int InsertBooking(Booking booking)
        {
            string query = $"INSERT INTO bookings (ID, StartTime, EndTime, PeopleAmount, Status, CreatedAt)"+
                         $"VALUES ('{booking.ID}', '{booking.StartTime}', '{booking.EndTime}', '{booking.PeopleAmount}', '{booking.Status}', '{booking.CreatedAt}');";
            return this.Insert(query);
        }

        public int InsertBooking(Booking booking, List<User> users)
        {
            int id = InsertBooking(booking);
            foreach(var user in users)
            {
                AddUsersToBooking(user.Id, id);
            }
            return id;
        }

        public void AddUsersToBooking(int userId, int bookingId)
        {
            string query = $"INSERT INTO usersinbooking(User, Booking)" +
                $"VALUES('{userId}', '{bookingId}');";
            Insert(query);
        }

        public List<User> GetUsersByBooking(int bookingId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = $"SELECT * FROM user " +
                $"INNER JOIN usersinbooking on user.Id = usersinbooking.User " +
                $"WHERE Type = {StudentType} AND Booking = {bookingId};";

            MySqlCommand commandDatabase = new MySqlCommand(query, connection);
            List<User> users = new List<User>();

            try
            {
                connection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];

                    users.Add(new User(id, name));

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        
        }
    }
}