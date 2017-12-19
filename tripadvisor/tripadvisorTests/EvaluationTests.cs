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
    public class EvaluationTests
    {
        [TestMethod()]
        public void EvaluationTest()
        {
            User user1 = new User("cley", "123");
            User user2 = new User("cley2", "123");
            Evaluation evaluation1 = new Evaluation("muito legal", 2, user1);
            Evaluation evaluation2 = new Evaluation("gostei", 6, user1);
            Assert.AreNotEqual(evaluation1, evaluation2);
            Assert.AreEqual(evaluation1, new Evaluation("muito legal", 2, user1));
            Assert.AreNotEqual(evaluation1, new Evaluation("muito legal", 5, user1));
            Assert.AreNotEqual(evaluation1, new Evaluation("muito legal", 2, user2));
        }
    }
}