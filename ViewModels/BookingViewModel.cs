using SpacefinderApp.Services;
using SpacefinderApp.Data.Models;
using System.Collections.ObjectModel;
using System.Configuration;

public class BookingsViewModel
{
    private readonly BookingService _bookingService;
    public ObservableCollection<Bookings> UserBookings { get; set; }

    public BookingsViewModel()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["SpacefinderDB"].ConnectionString;
        _bookingService = new BookingService(connectionString);
        UserBookings = new ObservableCollection<Bookings>();

        LoadBookings(123); // Replace with actual user ID
    }

    private void LoadBookings(int userId)
    {
        var bookings = _bookingService.GetUserBookings(userId);
        UserBookings.Clear();
        foreach (var booking in bookings)
        {
            UserBookings.Add(booking);
        }
    }

    public bool CreateNewBooking(Bookings booking)
    {
        return _bookingService.MakeBooking(booking);
    }
}