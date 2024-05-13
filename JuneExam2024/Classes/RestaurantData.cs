using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2024.Classes
{
    public class RestaurantData : DbContext
    {
        //Properties
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        //Constructors
        public RestaurantData(string database) : base(database) { }
        public RestaurantData() : this("OODExam_AlisonDoyle") { }
    }
}
