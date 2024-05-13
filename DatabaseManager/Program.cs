using JuneExam2024.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create database model
            RestaurantData database = new RestaurantData();

            //Create database entities
            using (database)
            {
                //Create customers
                Customer c1 = new Customer() { Name = "Tom Jones", ContactNumber = "086-123 4567" };
                Customer c2 = new Customer() { Name = "Mary Smith", ContactNumber = "086 546 3214" };
                Customer c3 = new Customer() { Name = "Jo Doyle", ContactNumber = "087 1221 222" };
                Console.WriteLine("Created customers");

                //Add to database
                database.Customers.Add(c1);
                database.Customers.Add(c2);
                database.Customers.Add(c3);
                Console.WriteLine("Added customers to db");

                //Save changes
                database.SaveChanges();
                Console.WriteLine("Saved changes");

                //Check data was entered correctly
                var query = from customer in database.Customers
                            select customer;

                foreach (var customer in query)
                {
                    Console.WriteLine(customer.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
