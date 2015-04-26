using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCustomers : TestDbCopunContext
    {
        Customers c;
        Customers c1;
        Customers c2;
        [TestInitialize]
        public void TestInitCustomer()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
          //      db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");
            }
            c = new Customers();
            c.UserName = "Temp";
            c.Telephone = "049999999";
            c.Password = "bla";
            c.Email = "temp@temp.com";
            c.location = "Akko";
            c.age = 23;
            c.gender = "Male";
            c1 = new Customers();
            c1.UserName = "Tempo";
            c1.Telephone = "049999999";
            c1.Password = "bla";
            c1.Email = "work@maybe.com";
            c1.location = "Beer Sheava";
            c1.age = 40;
            c1.gender = "Female";
            c2 = new Customers();
            c2.UserName = "Usertesto";
            c2.Telephone = "049999999";
            c2.Password = "bla";
            c2.Email = "work@maybe.com";
            c2.location = "Arad";
            c2.age = 72;
            c2.gender = "Make";
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            using (var db = new TestDbCopunContext())
            {
                db.Customers.Add(c);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCustomer()
        {
            using (var db = new TestDbCopunContext())
            {
                
                db.Customers.Add(c);
                db.SaveChanges();
                db.Customers.Add(c);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCustomer()
        {
            using (var db = new TestDbCopunContext())
            {
                db.Customers.Add(c1);
                db.Customers.Remove(c1);
                db.SaveChanges();
            }
        }

    }
}
