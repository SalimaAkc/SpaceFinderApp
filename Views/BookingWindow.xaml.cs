using SpacefinderApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpacefinderApp.Views
{
    public partial class BookingWindow : Window
    {
        private BookingsViewModel _viewModel;

        public BookingWindow()
        {
            InitializeComponent();
            _viewModel = new BookingsViewModel();
            this.DataContext = _viewModel;
        }

        private void CreateBookingButton_Click(object sender, RoutedEventArgs e)
        {
            var newBooking = new Bookings
            {
                UserID = 123,
                StartTime = DateTime.Now.AddHours(1),
                EndTime = DateTime.Now.AddHours(3),
                Status = true,
                PeopleAmount = 4
            };

            var success = _viewModel.CreateNewBooking(newBooking);
            MessageBox.Show(success ? "Booking created!" : "Failed to create booking");
        }
    }
}
