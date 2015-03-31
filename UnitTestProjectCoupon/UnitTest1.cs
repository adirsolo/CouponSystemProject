using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTest1 : DbContext
    {
        Customer c;
        Customer c1;
        Customer c2;
        [TestInitialize]
        public void TestInitCustomer()
        {
            c = new Customer();
            c.UserName = "Temp";
            c.Telephone = 049999999;
            c.Password = "bla";
            c.Email = "temp@temp.com";
            c.location = "Akko";
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            using (var db = new CopunContext())
            {
                db.Customers.Add(c);
            }
        }

        [TestMethod]
        public void TestExistingCustomer()
        {
            using (var db = new CopunContext())
            {
                c1 = new Customer();
                c1.UserName = "Temp";
                c1.Telephone = 049999999;
                c1.Password = "bla";
                c1.Email = "temp@temp.com";
                c1.location = "Akko";
                c2 = new Customer();
                c2.UserName = "Temp";
                c2.Telephone = 049999999;
                c2.Password = "bla";
                c2.Email = "temp@temp.com";
                c2.location = "Akko";
                db.Customers.Add(c1);
                db.Customers.Add(c2);
            }
        }

    }
}
