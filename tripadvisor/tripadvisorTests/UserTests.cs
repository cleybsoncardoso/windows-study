using Microsoft.VisualStudio.TestTools.UnitTesting;
using tripadvisor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor.model.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            User user1 = new User("Cleybson", "123");
            Assert.AreEqual(user1, new User("Cleybson", "123"));
            Assert.AreNotEqual(user1, new User("cleybson", "123"));
        }
    }
}