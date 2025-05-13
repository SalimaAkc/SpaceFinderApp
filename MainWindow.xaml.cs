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


namespace SpacefinderApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            statusText.Text = "Ready";
        }

        private void ShowBookingWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookingWindow = new BookingWindow();
                bookingWindow.Owner = this; // Set parent window
                bookingWindow.Closed += (s, args) => statusText.Text = "Booking window closed";
                bookingWindow.Show();
                statusText.Text = "Booking window opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}");
            }
        }
    }