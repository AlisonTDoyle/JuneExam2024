using JuneExam2024.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2024.Classes
{
    public class Booking
    {
        //Properties
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfParticipants { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //Methods
        public override string ToString()
        {
            //Dirty solution due to lack of time
            DatabaseHandler handler = new DatabaseHandler();
            Customer customer = handler.FetchCustomerById(CustomerId);
            return $"{customer.Name} ({customer.ContactNumber}) - Party of {NumberOfParticipants}";
        }
    }
}
