using JuneExam2024.Classes;
using JuneExam2024.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuneExam2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateBookingsListBox();
        }

        private void dpSearchDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateBookingsListBox();
        }
        #endregion

        #region Methods
        private void PopulateBookingsListBox()
        {
            DateTime? selectedDate = dpSearchDate.SelectedDate;

            if (selectedDate != null)
            {
                //Get bookings
                DatabaseHandler handler = new DatabaseHandler();
                List<Booking> bookings = handler.FetchBookingsByDate((DateTime)selectedDate);

                //Refresh listbox data
                lbxBookings.ItemsSource = null;
                lbxBookings.ItemsSource = bookings;
            }
        }
        #endregion
    }
}
