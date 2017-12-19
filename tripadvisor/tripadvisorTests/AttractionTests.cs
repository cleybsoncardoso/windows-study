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
    public class AttractionTests
    {
        [TestMethod()]
        public void AttractionTest()
        {
            User user1 = new User("cley", "123");
            Attraction attraction1 = new Attraction("kilogrio", "rua x");
            Attraction attraction2 = new Attraction("kilogrio", "rua x");
            attraction1.Evaluations.Add(new Evaluation("legal", 1, user1));
            attraction2.Evaluations.Add(new Evaluation("legal", 1, user1));
            Assert.AreEqual(attraction1, attraction2);
            attraction1.Evaluations.Add(new Evaluation("legal", 2, user1));
            Assert.AreNotEqual(attraction1, attraction2);
            attraction1.Evaluations.RemoveRange(1, 1);
            Assert.AreEqual(attraction1, attraction2);

        }
    }
}