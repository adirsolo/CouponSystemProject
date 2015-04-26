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
        //        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [CustomersFavoriteCatagories]");
            }
            cfc = new CustomersFavoriteCatagories();
            cfc.Category = 1;
            cfc.UserName = "Temp";
            cfc1 = new CustomersFavoriteCatagories();
            cfc1.Category = 1;
            cfc1.UserName = "Tempo";
            cfc2 = new CustomersFavoriteCatagories();
            cfc2.Category = 1;
            cfc2.UserName = "Usertesto";
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
