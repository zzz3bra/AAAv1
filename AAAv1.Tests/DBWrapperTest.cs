using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AAAv1.Models;

namespace AAAv1.Tests
{
    /// <summary>
    ///  Тестирование работы связи с БД
    /// </summary>
    [TestClass]
    public class DBWrapperTest
    {
        UserBase testBase;
        UserRecord testRecord;
        public DBWrapperTest()
        {
            testBase = UserBase.Instance;
            testRecord = UserBase.Instance.CurrentUser;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestDBCreation()
        {
            Assert.IsNotNull(testBase);
        }
        [TestMethod]
        public void TestAddUser()
        {
            Assert.IsTrue(testBase.AddUser("email", "pass") != -1);
        }
        [TestMethod]
        public void TestAddFavouriteToUser()
        {
            testRecord = testBase.GetUserByCredentials("email", "pass");
            int beforeCount = testRecord.FavouriteADS.Count;
            testRecord.AddFavouriteADS(new ADS());
            int afterCount = testRecord.FavouriteADS.Count;
            Assert.IsTrue(afterCount == beforeCount + 1);
        }
        [TestMethod]
        public void TestIdealCarIsCreated()
        {
            Assert.IsNotNull(testRecord.GetIdealCar());
        }
        [TestMethod]
        public void TestRemoveUser()
        {
            testBase.RemoveUserAccount("email");
        }
    }
}
