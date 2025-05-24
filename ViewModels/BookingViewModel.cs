using SpacefinderApp.Data;
using SpacefinderApp.Model;
using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Input;

public class BookingViewModel : INotifyPropertyChanged
{
    private readonly BookingRepository _bookingRepo;
    public ObservableCollection<TimeSlot> AvailableSlots { get; set; }

    public ICommand BookRoomCommand => new RelayCommand(BookRoom);

    private void BookRoom()
    {
        var booking = new Booking { RoomId = SelectedRoom.Id, ... };
        _bookingRepo.AddBooking(booking);
    }
}