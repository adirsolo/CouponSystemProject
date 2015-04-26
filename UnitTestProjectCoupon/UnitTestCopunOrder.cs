using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCopunOrder : TestDbCopunContext
    {
        CopunOrder co;
        CopunOrder co1;
        CopunOrder co2;
        [TestInitialize]
        public void TestInitCopunOrder()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
       //         db.Database.ExecuteSqlCommand("TRUNCATE TABLE [CopunOrder]");
            }
            co = new CopunOrder();
            co.OrderKey = 3;
            co.Status = "Very good";
            co.CustomerRating = 6;
            co.OrderDate = DateTime.Today;
            co.CopunName = "half";
            co.CustomerName = "Temp";
            co1 = new CopunOrder();
            co1.OrderKey = 4;
            co1.Status = "Good";
            co1.CustomerRating = 6;
            co1.OrderDate = DateTime.Today;
            co1.CopunName = "gogo";
            co1.CustomerName = "Tempo";
            co2 = new CopunOrder();
            co2.OrderKey = 5;
            co2.Status = "Very good";
            co2.CustomerRating = 6;
            co2.OrderDate = DateTime.Today;
            co2.CopunName = "koko";
            co2.CustomerName = "Usertesto";
        }

        [TestMethod]
        public void TestAddCopunOrder()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.CopunOrder.Add(co);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCopunOrder()
        {
            using (var db = new TestDbCopunContext())
            {
                db.CopunOrder.Add(co);
                db.SaveChanges();
                db.CopunOrder.Add(co);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCopunOrder()
        {
            using (var db = new TestDbCopunContext())
            {
                db.CopunOrder.Add(co1);
                db.CopunOrder.Remove(co1);
                db.SaveChanges();
            }
        }

    }
}
