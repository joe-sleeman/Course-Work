using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Joe_Slee_Aggregator;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUserID_ReturnCorrectUserID()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            int expected = 1;
            int actual = dbMan.GetUserIDFromUsername("Joe");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfUserExists_ReturnTrue()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            bool expected = true;
            bool actual = dbMan.CheckIfUserExists("Joe");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestIfUserExists_ReturnFalse()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            bool expected = false;
            bool actual = dbMan.CheckIfUserExists("Andrew");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfUserHasTopics_ReturnTopicName()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            User Joe = new User{ Username = "Joseph", Password = "password" };
            aggDB.Users.Add(Joe);   // Don't save
           
            List<Topic> userTopics = dbMan.GetAllLikedTopicsForUser(Joe);
            
            string expected = "Skateboarding";
            string actual = userTopics[0].TopicName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUsernameAndPassword_ReturnTrue()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            bool expected = true;
            bool actual = dbMan.CheckUsernameAndPassword("Joe", "Password");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckUsernameAndPassword_WithBadPassword_ReturnFalse()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            bool expected = false;
            bool actual = dbMan.CheckUsernameAndPassword("Joe", "IncorrectPassword");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetUserFromUsername_ReturnUserObject()
        {
            AggregatorDBContext aggDB = new AggregatorDBContext();
            DBManager dbMan = new DBManager();

            string expected = "Joe";
            User user = dbMan.GetUserFromUsername("Joe");
            string actual = user.Username;

            Assert.AreEqual(expected, actual);
        }
    }
}
