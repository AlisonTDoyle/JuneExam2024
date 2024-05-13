using JuneExam2024.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuneExam2024.Utilities
{
    internal class DatabaseHandler
    {
        RestaurantData db = new RestaurantData();

        public List<Booking> FetchBookingsByDate(DateTime bookingDate)
        {
            //Query database for bookings
            var query = from booking in db.Bookings
                        where booking.BookingDate == bookingDate
                        select booking;

            return query.ToList();
        }

        public List<Customer> FetchCustomers()
        {
            var query = from customer in db.Customers
                        select customer;

            return query.ToList();
        }

        public List<Customer> FetchCustomersByName(string name)
        {
            var query = from customer in db.Customers
                        where customer.Name.Contains(name)
                        select customer;

            return query.ToList();
        }

        public Customer FetchCustomerByName(string name)
        {
            var query = (from customer in db.Customers
                        where customer.Name == name
                        select customer).FirstOrDefault();

            return query;
        }

        public Customer FetchCustomerById(int id)
        {
            var query = (from customer in db.Customers
                         where customer.CustomerId == id
                         select customer).FirstOrDefault();

            return query;
        }

        public void CreateCustomer(Customer newCustomer)
        {
            try
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void CreateBooking(Booking newBooking)
        {
            try
            {
                db.Bookings.Add(newBooking);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void DeleteBooking(Booking booking)
        {
            try
            {
                db.Bookings.Remove(booking);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
