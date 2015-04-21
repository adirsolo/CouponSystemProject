using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestOrders : TestDbCopunContext
    {
        Order o;
        Order o1;
        Order o2;
        [TestInitialize]
        public void TestInitOrder()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Orders]");
            }
            o = new Order();
            o.CopunName = "half";
            o.CustemrName = "Sharki";
            o.OrderKey = 3;
            o.rating = 5.0;
            o.status = "Used";
            o1 = new Order();
            o1.CopunName = "full";
            o1.CustemrName = "Sharki";
            o1.OrderKey = 3;
            o1.rating = 5.0;
            o1.status = "Used";
            o2 = new Order();
            o2.CopunName = "qutro";
            o2.CustemrName = "Sharki";
            o2.OrderKey = 3;
            o2.rating = 5.0;
            o2.status = "Used";
        }

        [TestMethod]
        public void TestAddOrder()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.Orders.Add(o);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingOrder()
        {
            using (var db = new TestDbCopunContext())
            {

                db.Orders.Add(o);
                db.SaveChanges();
                db.Orders.Add(o);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            using (var db = new TestDbCopunContext())
            {
                db.Orders.Add(o1);
                db.Orders.Remove(o1);
                db.SaveChanges();
            }
        }

    }
}
