using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCustomersFavoriteCatagories : TestDbCopunContext
    {
        CustomersFavoriteCatagories cfc;
        CustomersFavoriteCatagories cfc1;
        CustomersFavoriteCatagories cfc2;
        [TestInitialize]
        public void TestInitCustomersFavoriteCatagories()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [CustomersFavoriteCatagories]");
            }
            cfc = new CustomersFavoriteCatagories();
            cfc.Category = "Food";
            cfc.UserName = "sharki";
            cfc1 = new CustomersFavoriteCatagories();
            cfc1.Category = "Food";
            cfc1.UserName = "sharki1";
            cfc2 = new CustomersFavoriteCatagories();
            cfc2.Category = "Food";
            cfc2.UserName = "sharki2";
        }

        [TestMethod]
        public void TestAddCustomersFavoriteCatagories()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.CustomersFavoriteCatagories.Add(cfc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCustomersFavoriteCatagories()
        {
            using (var db = new TestDbCopunContext())
            {
                db.CustomersFavoriteCatagories.Add(cfc);
                db.SaveChanges();
                db.CustomersFavoriteCatagories.Add(cfc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCustomersFavoriteCatagories()
        {
            using (var db = new TestDbCopunContext())
            {
                db.CustomersFavoriteCatagories.Add(cfc1);
                db.CustomersFavoriteCatagories.Remove(cfc1);
                db.SaveChanges();
            }
        }

    }
}
