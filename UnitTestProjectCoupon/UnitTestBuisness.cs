using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestBuisness : TestDbCopunContext
    {
        Buisnesses b;
        Buisnesses b1;
        Buisnesses b2;
        [TestInitialize]
        public void TestInitBuisness()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
       //         db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Buisnesses]");
            }
            b = new Buisnesses();
            b.Name = "Pizza";
            b.City = "Tel-Aviv";
            b.Address = "Sara-lavi tenai 3";
            b.BuisnessOwnerName = "temp";
            b.Category = 1;
            b.Description = "Good";
            b1 = new Buisnesses();
            b1.Name = "Hamburger";
            b1.City = "Tel-Aviv";
            b1.Address = "Sara-lavi tenai 9";
            b1.BuisnessOwnerName = "temp2";
            b1.Category = 1;
            b1.Description = "Nice";
            b2 = new Buisnesses();
            b2.Name = "Bank";
            b2.City = "Tel-Aviv";
            b2.Address = "Sara 9";
            b2.BuisnessOwnerName = "temp3";
            b2.Category = 2;
            b2.Description = "Bad";
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
