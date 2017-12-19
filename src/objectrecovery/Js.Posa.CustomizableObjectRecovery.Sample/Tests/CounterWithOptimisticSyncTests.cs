namespace Js.Posa.CustomizableObjectRecovery.Sample.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;

    [TestClass]
    public class CounterWithOptimisticSyncTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void NonConcurrentCounterOperations()
        {
            var sharedCounter = new Counter();
            var counter1 = new Model.CounterWithOptimisticSync(sharedCounter);
            var counter2 = new Model.CounterWithOptimisticSync(sharedCounter);

            counter1.Increase();
            counter1.Increase();

            Assert.AreEqual(2, counter1.Value);
            Assert.AreEqual(2, counter2.Value);
        }

        [UnitTest]
        [TestMethod]
        public void ConflictingCounterOperation()
        {
            var sharedCounter = new Counter();
            var counter1 = new Model.CounterWithOptimisticSync(sharedCounter);
            var counter2 = new Model.CounterWithOptimisticSync(sharedCounter);


            counter1.Increase();
            counter2.Increase();

            Assert.AreEqual(1, sharedCounter.Value);
        }

    }
}
