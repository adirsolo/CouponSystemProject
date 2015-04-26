using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestCopun : TestDbCopunContext
    {
        Copuns c;
        Copuns c1;
        Copuns c2;
        [TestInitialize]
        public void TestInitCopun()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
    //            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Copuns]");
            }
            c = new Copuns();
            c.BuisnessName = "Pizza";
            c.CopunPrice = 23.0;
            c.Description = "temp desc";
            c.Name = "half";
            c.Category = 1;
            c.OriginalPrice = 46;
            c1 = new Copuns();
            c1.BuisnessName = "Hamburger";
            c1.CopunPrice = 23.0;
            c1.Description = "temp desc";
            c1.Name = "gogo";
            c1.OriginalPrice = 46;
            c1.Category = 5;
            c2 = new Copuns();
            c2.BuisnessName = "Bank";
            c2.CopunPrice = 23.0;
            c2.Description = "temp desc kolo";
            c2.Name = "koko";
            c2.OriginalPrice = 46;
            c2.Category = 5;
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
