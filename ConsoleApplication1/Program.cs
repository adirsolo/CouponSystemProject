using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CopunContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Copun: ");
                var name = Console.ReadLine();

                var copun = new Copuns { Name = name };
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

    public class Buisnesses
    {
        [Key]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        [ForeignKey("BuisnessOwners")]
        [Column(Order = 1)] 
        public string BuisnessOwnerName { get; set; }
        //CONSTRAINT [PK_dbo.Buisnesses] PRIMARY KEY CLUSTERED ([Name] ASC),
        //CONSTRAINT [FK_Buisnesses_ToBuisnessOwners] FOREIGN KEY ([BuisnessOwnerName]) REFERENCES [dbo].[BuisnessOwners] ([UserName])
        public BuisnessOwners BuisnessOwners { get; set; }
    }

    public class BuisnessOwners
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        //CONSTRAINT [PK_dbo.BuisnessOwners] PRIMARY KEY CLUSTERED ([UserName] ASC)
    }

    public class CopunOrder
    {
        [Key]
        public int OrderKey { get; set; }
        public string Status { get; set; }
        public int CustomerRating { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("Copuns")]
        [Column(Order = 1)] 
        public string CopunName { get; set; }
        public Copuns Copuns { get; set; }

        [ForeignKey("Customers")]
        [Column(Order = 2)] 
        public string CustomerName { get; set; }
        public Customers Customers { get; set; }
        // PRIMARY KEY CLUSTERED ([OrderKey] ASC),
        // CONSTRAINT [FK_CopunOrder_ToCopun] FOREIGN KEY ([CopunName]) REFERENCES [dbo].[Copuns] ([Name]),
        //CONSTRAINT [FK_CopunOrder_ToCustomer] FOREIGN KEY ([CustomerName]) REFERENCES [dbo].[Customers] ([UserName])
    }

    public class Copuns
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public double OriginalPrice { get; set; }
        public double CopunPrice { get; set; }
        [ForeignKey("Buisnesses")]
        [Column(Order = 1)] 
        public string BuisnessName { get; set; }
        //  CONSTRAINT [PK_dbo.Copuns] PRIMARY KEY CLUSTERED ([Name] ASC),
        //  CONSTRAINT [FK_Copuns_ToBuisness] FOREIGN KEY ([BuisnessName]) REFERENCES [dbo].[Buisnesses] ([Name])
        public Buisnesses Buisnesses { get; set; }
    }

    public class Customers
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string location { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        //CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([UserName] ASC)
    }

    public class CustomersFavoriteCatagories
    {
        [Key]
        [ForeignKey("Customers")]
        [Column(Order = 1)] 
        public string UserName { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Category { get; set; }
        // CONSTRAINT [PK_dbo.CustomersFavoriteCatagories] PRIMARY KEY CLUSTERED ([UserName] ASC, [Category] ASC),
        // CONSTRAINT [FK_CustomersFavoriteCatagories_ToCustomer] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Customers] ([UserName])
        public Customers Customers { get; set; }
    }

    public class SocialCopun
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public double OriginalPrice { get; set; }
        public double CopunPrice { get; set; }
        public double rating { get; set; }
        public DateTime expired { get; set; }
        [ForeignKey("Buisnesses")]
        [Column(Order = 1)]
        public string BuisnessName { get; set; }
        // CONSTRAINT [PK_dbo.SocialCopun] PRIMARY KEY CLUSTERED ([Name] ASC),
        //  CONSTRAINT [FK_SocialCopun_ToBuisness] FOREIGN KEY ([BuisnessName]) REFERENCES [dbo].[Buisnesses] ([Name])
        public Buisnesses Buisnesses { get; set; }
    }

    public class SystemManagers
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        //  CONSTRAINT [PK_dbo.SystemManagers] PRIMARY KEY CLUSTERED ([UserName] ASC)
    }

    public class CopunContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Buisnesses> Buisnesses { get; set; }
        public DbSet<BuisnessOwners> BuisnessOwners { get; set; }
        public DbSet<CopunOrder> CopunOrder { get; set; }
        public DbSet<Copuns> Copuns { get; set; }
        public DbSet<CustomersFavoriteCatagories> CustomersFavoriteCatagories { get; set; }
        public DbSet<SocialCopun> SocialCopun { get; set; }
        public DbSet<SystemManagers> SystemManagers { get; set; }
    }
}
