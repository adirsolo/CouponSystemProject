using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstNewDataBase;
using System.Data.Entity;

namespace UnitTestProjectCoupon
{
    [TestClass]
    public class UnitTestSystemManager : TestDbCopunContext
    {
        SystemManager s;
        SystemManager s1;
        SystemManager s2;
        [TestInitialize]
        public void TestInitSystemManager()
        {
            //making sure the table is empty
            using (var db = new TestDbCopunContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SystemManagers]");
            }
            s = new SystemManager();
            s.Email = "bla@bla.com";
            s.Password = "xyz";
            s.Telephone = 09999999;
            s.UserName = "temp";
            s1 = new SystemManager();
            s1.Email = "bla@bla1.com";
            s1.Password = "xyz";
            s1.Telephone = 09999999;
            s1.UserName = "temp1";
            s2 = new SystemManager();
            s2.Email = "bla@bla2.com";
            s2.Password = "xyz";
            s2.Telephone = 09999999;
            s2.UserName = "temp2";

        }

        [TestMethod]
        public void TestAddSystemManager()
        {
            using (var db = new TestDbCopunContext())
            //CopunContext db;
            {
                db.SystemManagers.Add(s);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAddExisitingSystemManager()
        {
            using (var db = new TestDbCopunContext())
            {
                db.SystemManagers.Add(s);
                db.SaveChanges();
                db.SystemManagers.Add(s);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteSystemManager()
        {
            using (var db = new TestDbCopunContext())
            {
                db.SystemManagers.Add(s1);
                db.SystemManagers.Remove(s1);
                db.SaveChanges();
            }
        }

    }
}
