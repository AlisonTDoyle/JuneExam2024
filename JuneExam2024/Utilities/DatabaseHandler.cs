using JuneExam2024.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
