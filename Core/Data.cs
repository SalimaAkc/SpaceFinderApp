using MySql.Data.MySqlClient;
using MySqlConnector;
using SpacefinderApp.Data.Models;
using System;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Generators;

namespace SpacefinderApp.Data
{
    public class Data
    {
        private string connectionString = "server=127.0.0.1;port=3306;username=root;password=;database=spacefinder;";

        public int CreateUser(string fullName, string email, string password, bool isTeacher)
        {
            if (!IsSchoolEmail(email)) throw new ArgumentException("Invalid school email");

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO Users (FullName, SchoolEmail, PasswordHash, IsTeacher)
                        VALUES (@fullName, @email, @passwordHash, @isTeacher);
                        SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@fullName", fullName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(password));
            cmd.Parameters.AddWithValue("@isTeacher", isTeacher);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public User Authenticate(string email, string password)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = "SELECT * FROM Users WHERE SchoolEmail = @email AND IsDeleted = FALSE";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var storedHash = reader["PasswordHash"].ToString();
                if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                {
                    return new User(
                        Convert.ToInt32(reader["Id"]),
                        reader["FullName"].ToString(),
                        reader["SchoolEmail"].ToString(),
                        Convert.ToBoolean(reader["IsTeacher"])
                    );
                }
            }
            return null;
        }

        public bool IsClassroomAvailable(int classroomId, DateTime start, DateTime end)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"SELECT COUNT(*) FROM Bookings 
                        WHERE ClassroomId = @classroomId 
                        AND ((StartTime < @end) AND (EndTime > @start))";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@classroomId", classroomId);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);

            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        private bool IsSchoolEmail(string email)
        {
            return email.EndsWith("@student.thomasmore.be"); 
        }
    }

    public record User(int Id, string FullName, string Email, bool IsTeacher);
}