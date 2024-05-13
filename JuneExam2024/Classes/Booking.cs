using System;
using System.Collections.Generic;
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
            return $"{Customer.Name} ({Customer.ContactNumber} - Party of {NumberOfParticipants})";
        }
    }
}
