using SpacefinderApp.Data;
using SpacefinderApp.Model;
using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

public class BookingViewModel
{
    public ICommand SelectCampusCommand { get; } = new RelayCommand<string>(SelectCampus);

    private static void SelectCampus(string campusName)
    {
        // Handle campus selection logic
        MessageBox.Show($"Selected campus: {campusName}");
    }
}