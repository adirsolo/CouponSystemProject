using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTestDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDbCopunContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Copun: ");
                var name = Console.ReadLine();

                var copun = new Copun { Name = name };
                db.Copuns.Add(copun);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Copuns
                            orderby b.Name
                            select b;

                Console.WriteLine("All Copuns in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class Customer
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string location { get; set; }
    }
    public class CustomersFavoriteCatagories
    {
        [Key]
        public string UserName { get; set; }
        public string Category { get; set; }
    }
    public class CustomerCopuns
    {
        [Key]
        public string CustomerName { get; set; }
        public string CopunName { get; set; }

    }

    public class SystemManager
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }

    }
    public class BuisnessOwner
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
    }
    public class Copun
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double OriginalPrice { get; set; }
        public double CopunPrice { get; set; }
        public double rating { get; set; }
        public string expired { get; set; }
        public string BuisnessName { get; set; }
    }

    public class Buisness
    {
        [Key]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double Description { get; set; }
        public double Category { get; set; }
        public string BuisnessOwnerName { get; set; }
    }

    public class Order
    {
        [Key]
        public string CustemrName { get; set; }
        public string CopunName { get; set; }
        public int OrderKey { get; set; }
        public string status { get; set; }
        public double rating { get; set; }

    }

    public class TestDbCopunContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomersFavoriteCatagories> CustomersFavoriteCatagories { get; set; }
        public DbSet<CustomerCopuns> CustomerCopuns { get; set; }
        public DbSet<SystemManager> SystemManagers { get; set; }
        public DbSet<BuisnessOwner> BuisnessOwners { get; set; }
        public DbSet<Copun> Copuns { get; set; }
        public DbSet<Buisness> Buisnesses { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
