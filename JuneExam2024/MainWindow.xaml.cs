using JuneExam2024.Classes;
using JuneExam2024.Utilities;
using JuneExam2024.Windows;
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
            PopulateNumberOfCutomerTextboxPlaceholder();
            PopulateNameTextboxPlaceholder();
            PopulateContactTextboxPlaceholder();
        }

        private void dpSearchDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateBookingsInfo();
        }

        private void btnCustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenAndPassDataToCustomerSearch();
        }

        private void tbxNumberOfCustomers_LostFocus(object sender, RoutedEventArgs e)
        {
            PopulateNumberOfCutomerTextboxPlaceholder();
        }

        private void tbxCustomerName_LostFocus(object sender, RoutedEventArgs e)
        {
            PopulateNameTextboxPlaceholder();
        }

        private void tbxContactNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            PopulateContactTextboxPlaceholder();
        }

        private void tbxNumberOfCustomers_GotFocus(object sender, RoutedEventArgs e)
        {
            SetTextBoxToNull(tbxNumberOfCustomers);
        }

        private void tbxCustomerName_GotFocus(object sender, RoutedEventArgs e)
        {
            SetTextBoxToNull(tbxCustomerName);
        }

        private void tbxContactNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            SetTextBoxToNull(tbxContactNumber);
        }

        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            DeleteBooking();
        }
        #endregion

        #region Methods
        private void PopulateBookingsInfo()
        {
            const int RestaurantCapacity = 40;
            DateTime? selectedDate = dpSearchDate.SelectedDate;

            //Check if selected date is null
            if (selectedDate != null)
            {
                //Get bookings
                DatabaseHandler handler = new DatabaseHandler();
                List<Booking> bookings = handler.FetchBookingsByDate((DateTime)selectedDate);

                //Refresh listbox data
                lbxBookings.ItemsSource = null;
                lbxBookings.ItemsSource = bookings;

                // Calc seats available
                int seatsAvailable = RestaurantCapacity;
                foreach (Booking booking in bookings)
                {
                    seatsAvailable -= booking.NumberOfParticipants;
                }

                //Refresh other stats
                tblkCapacity.Text = RestaurantCapacity.ToString();
                tblkBookings.Text = bookings.Count.ToString();
                tblkAvailable.Text = seatsAvailable.ToString();
            }
        }
        
        public void OpenAndPassDataToCustomerSearch()
        {
            //Validate data
            DateTime? selectedDate = dpNewBookingDate.SelectedDate;
            string enteredNumberOfCustomers = tbxNumberOfCustomers.Text;
            string customerName = tbxCustomerName.Text;
            string contactNumber = tbxContactNumber.Text;

            //Check all feilds are filled in
            if ((selectedDate != null) && (!string.IsNullOrEmpty(enteredNumberOfCustomers)) && (!string.IsNullOrEmpty(customerName)) && (!string.IsNullOrEmpty(contactNumber)))
            {
                //Check value entered for no of customers is a positive int
                if ((int.TryParse(enteredNumberOfCustomers, out int numberOfCustomers)) && (numberOfCustomers > 0))
                {
                    CustomerSearch customerSearch = new CustomerSearch((DateTime)selectedDate, numberOfCustomers, customerName, contactNumber);
                    customerSearch.Show();
                }
                else
                {
                    MessageBox.Show("Please enter a positive numerical value for number of customers", "Error");
                }
            } 
            else
            {
                MessageBox.Show("Fill in all feilds before creating a booking.", "Error");
            }
        }
        
        public void PopulateNumberOfCutomerTextboxPlaceholder()
        {
            if (string.IsNullOrEmpty(tbxNumberOfCustomers.Text))
            {
                tbxNumberOfCustomers.Text = "Number of Customers";
            }
        }

        public void PopulateNameTextboxPlaceholder()
        {
            if (string.IsNullOrEmpty(tbxCustomerName.Text))
            {
                tbxCustomerName.Text = "Customer Name";
            }
        }

        public void PopulateContactTextboxPlaceholder()
        {
            if (string.IsNullOrEmpty (tbxContactNumber.Text))
            {
                tbxContactNumber.Text = "Contact Number";
            }
        }

        public void SetTextBoxToNull(TextBox textbox)
        {
            textbox.Text = "";
        }
        
        public void DeleteBooking()
        {
            if(lbxBookings.SelectedItem != null)
            {
                Booking bookingToDelete = lbxBookings.SelectedItem as Booking;
                DatabaseHandler handler = new DatabaseHandler();
                handler.DeleteBooking(bookingToDelete);
            }
        }
        #endregion
    }
}
