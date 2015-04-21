using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCustomerCopuns : TestDbCopunContext
    {
        CustomerCopuns cc;
        CustomerCopuns cc1;
        CustomerCopuns cc2;
        [TestInitialize]
        public void TestInitCustomerCopuns()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [CustomerCopuns]");
            }
            cc = new CustomerCopuns();
            cc.CopunName = "half";
            cc.CustomerName = "Sharki";
            cc1 = new CustomerCopuns();
            cc1.CopunName = "full";
            cc1.CustomerName = "Sharki1";
            cc2 = new CustomerCopuns();
            cc2.CopunName = "half";
            cc2.CustomerName = "Sharki2";
        }

        [TestMethod]
        public void TestAddCustomerCopuns()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.CustomerCopuns.Add(cc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCustomerCopuns()
        {
            using (var db = new TestDbCopunContext())
            {

                db.CustomerCopuns.Add(cc);
                db.SaveChanges();
                db.CustomerCopuns.Add(cc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCustomerCopuns()
        {
            using (var db = new TestDbCopunContext())
            {
                db.CustomerCopuns.Add(cc1);
                db.CustomerCopuns.Remove(cc1);
                db.SaveChanges();
            }
        }

    }
}
