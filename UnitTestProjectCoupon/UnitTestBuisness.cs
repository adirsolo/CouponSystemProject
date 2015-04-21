using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestBuisness : TestDbCopunContext
    {
        Buisness b;
        Buisness b1;
        Buisness b2;
        [TestInitialize]
        public void TestInitBuisness()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Buisnesses]");
            }
            b = new Buisness();
            b.Name = "Pizza";
            b.City = "Tel-Aviv";
            b.Address = "Sara-lavi tenai 3";
            b.BuisnessOwnerName = "Nimrod";
            b.Category = 1.0;
            b.Description = 9.0;
            b1 = new Buisness();
            b1.Name = "Hamburger";
            b1.City = "Tel-Aviv";
            b1.Address = "Sara-lavi tenai 9";
            b1.BuisnessOwnerName = "Nimrod";
            b1.Category = 1.0;
            b1.Description = 2.0;
            b2 = new Buisness();
            b2.Name = "Bank";
            b2.City = "Tel-Aviv";
            b2.Address = "Sara 9";
            b2.BuisnessOwnerName = "Adir";
            b2.Category = 2.0;
            b2.Description = 6.0;
        }

        [TestMethod]
        public void TestAddBuisness()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.Buisnesses.Add(b);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingBuisnesses()
        {
            using (var db = new TestDbCopunContext())
            {

                db.Buisnesses.Add(b);
                db.SaveChanges();
                db.Buisnesses.Add(b);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteBuisnesses()
        {
            using (var db = new TestDbCopunContext())
            {
                db.Buisnesses.Add(b1);
                db.Buisnesses.Remove(b1);
                db.SaveChanges();
            }
        }

    }
}
