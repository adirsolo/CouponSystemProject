using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestSocialCopun : TestDbCopunContext
    {
        SocialCopun sc;
        SocialCopun sc1;
        [TestInitialize]
        public void TestInitCopun()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
           //     db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SocialCopun]");
            }
            sc = new SocialCopun();
            sc.Name = "HalfSocial";
            sc.Description = "Best copun ever";
            sc.Category = 3;
            sc.OriginalPrice = 4.1;
            sc.CopunPrice = 3.2;
            sc.rating = 1.3;
            sc.expired = DateTime.Today;
            sc.BuisnessName = "Pizza";
            sc1 = new SocialCopun();
            sc1.Name = "HalfSocial";
            sc1.Description = "Not very good";
            sc1.Category = 3;
            sc1.OriginalPrice = 4.1;
            sc1.CopunPrice = 3.2;
            sc1.rating = 1.3;
            sc1.expired = DateTime.Today;
            sc1.BuisnessName = "Hamburger";
        }

        [TestMethod]
        public void TestAddCopun()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.SocialCopun.Add(sc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingCopun()
        {
            using (var db = new TestDbCopunContext())
            {

                db.SocialCopun.Add(sc);
                db.SaveChanges();
                db.SocialCopun.Add(sc);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteCopun()
        {
            using (var db = new TestDbCopunContext())
            {
                db.SocialCopun.Add(sc1);
                db.SocialCopun.Remove(sc1);
                db.SaveChanges();
            }
        }

    }
}
