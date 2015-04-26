using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestBuisnessOwner : TestDbCopunContext
    {
        BuisnessOwners bo;
        BuisnessOwners bo1;
        BuisnessOwners bo2;
        [TestInitialize]
        public void TestInitBuisnessOwner()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
         //       db.Database.ExecuteSqlCommand("TRUNCATE TABLE [BuisnessOwners]");
            }
            bo = new BuisnessOwners();
            bo1 = new BuisnessOwners();
            bo2 = new BuisnessOwners();
            bo.UserName = "temp";
            bo.Telephone = "9811111";
            bo.Password = "xyz";
            bo.Email = "yeah@right.com";
            bo1.UserName = "temp2";
            bo1.Telephone = "9811111";
            bo1.Password = "xyz";
            bo1.Email = "yeah2@right.com";
            bo2.UserName = "temp3";
            bo2.Telephone = "9811111";
            bo2.Password = "xyz";
            bo2.Email = "yeah3@right.com";
        }

        [TestMethod]
        public void TestAddBuisnessOwner()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.BuisnessOwners.Add(bo);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingBuisnessOwner()
        {
            using (var db = new TestDbCopunContext())
            {

                db.BuisnessOwners.Add(bo);
                db.SaveChanges();
                db.BuisnessOwners.Add(bo);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteBuisnessOwner()
        {
            using (var db = new TestDbCopunContext())
            {
                db.BuisnessOwners.Add(bo1);
                db.BuisnessOwners.Remove(bo1);
                db.SaveChanges();
            }
        }

    }
}
