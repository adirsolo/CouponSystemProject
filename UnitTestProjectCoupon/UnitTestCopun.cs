using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCopun : TestDbCopunContext
    {
        Copun c;
        Copun c1;
        Copun c2;
        [TestInitialize]
        public void TestInitCopun()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Copuns]");
            }
            c = new Copun();
            c.BuisnessName = "Pizza";
            c.Category = "tests";
            c.CopunPrice = 23.0;
            c.Description = "temp desc";
            c.expired = "01.02.17";
            c.Name = "half";
            c.OriginalPrice = 46;
            c.rating = 5;
            c1 = new Copun();
            c1.BuisnessName = "Bank";
            c1.Category = "tests";
            c1.CopunPrice = 23.0;
            c1.Description = "temp desc";
            c1.expired = "01.02.17";
            c1.Name = "gogo";
            c1.OriginalPrice = 46;
            c1.rating = 5;
            c2 = new Copun();
            c2.BuisnessName = "Hamburger";
            c2.Category = "Food";
            c2.CopunPrice = 23.0;
            c2.Description = "temp desc kolo";
            c2.expired = "01.02.19";
            c2.Name = "koko";
            c2.OriginalPrice = 46;
            c2.rating = 5;
        }

        [TestMethod]
        public void TestAddCopun()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.Copuns.Add(c);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCopun()
        {
            using (var db = new TestDbCopunContext())
            {

                db.Copuns.Add(c);
                db.SaveChanges();
                db.Copuns.Add(c);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCopun()
        {
            using (var db = new TestDbCopunContext())
            {
                db.Copuns.Add(c1);
                db.Copuns.Remove(c1);
                db.SaveChanges();
            }
        }

    }
}
