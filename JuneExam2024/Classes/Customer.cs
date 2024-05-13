using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2024.Classes
{
    public class Customer
    {
        //Properties
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
