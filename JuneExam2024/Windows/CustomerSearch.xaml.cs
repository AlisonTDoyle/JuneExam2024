using JuneExam2024.Classes;
using JuneExam2024.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace JuneExam2024.Windows
{
    /// <summary>
    /// Interaction logic for CustomerSearch.xaml
    /// </summary>
    public partial class CustomerSearch : Window
    {
        //Properties
        private DateTime _bookingDate;
        private int _numberOfCustomers;
        private string _customerName;
        private string _contactNumber;

        public CustomerSearch(DateTime bookingDate, int numberOfCustomers, string enteredName, string customerContactNumber)
        {
            InitializeComponent();

            _bookingDate = bookingDate;
            _numberOfCustomers = numberOfCustomers;
            _customerName = enteredName;
            _contactNumber = customerContactNumber;
        }

        #region Event Handlers
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateForm();
            PopulateListbox();
        }

        private void btnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateBooking();
        }
        #endregion

        #region Methods
        public void PopulateForm()
        {
            tbxName.Text = _customerName;
            tbxContactNumber.Text = _contactNumber;
            tblkDateOfBooking.Text = _bookingDate.ToString();
            tblkNumberOfCustomers.Text = _numberOfCustomers.ToString(); 
        }

        public void PopulateListbox()
        {
            //Fetch customers
            DatabaseHandler handler = new DatabaseHandler();
            List<Customer> customers = handler.FetchCustomersByName(tbxName.Text);

            //Populate listbox
            lbxCustomers.ItemsSource = null;
            lbxCustomers.ItemsSource = customers;
        }

        public void CreateBooking()
        {
            DatabaseHandler handler = new DatabaseHandler();

            //Check if a customer needs to be created
            Customer customer = handler.FetchCustomerByName(tbxName.Text);
            if (customer == null)
            {
                Customer newCustomer = new Customer() { Name = tbxName.Text, ContactNumber = _contactNumber};
                handler.CreateCustomer(newCustomer);

                // Get full new customer object
                customer = handler.FetchCustomerByName(tbxName.Text);
            }

            // Create booking
            Booking newBooking = new Booking() { NumberOfParticipants = _numberOfCustomers, BookingDate = _bookingDate, Customer = customer, CustomerId = customer.CustomerId};
            handler.CreateBooking(newBooking);

            MessageBox.Show("Booking Created", "Error");
        }
        #endregion
    }
}
