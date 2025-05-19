using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpacefinderApp.Views;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MySqlConnector;
using SpacefinderApp.Data.Models;


namespace SpacefinderApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadBookings();
        }
        private void LoadBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM bookings";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            Id = reader.GetInt32("id"),
                            UserId = reader.GetInt32("user_id"),
                            StartTime = reader.GetDateTime("start_time"),
                            EndTime = reader.GetDateTime("end_time"),
                            Status = reader.GetBoolean("status")
                        });
                    }
                }
            }

            BookingsGrid.ItemsSource = bookings;
        }
    }
}