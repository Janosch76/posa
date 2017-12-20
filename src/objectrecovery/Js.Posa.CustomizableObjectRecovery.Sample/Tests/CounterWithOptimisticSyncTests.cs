namespace Js.Posa.CustomizableObjectRecovery.Sample.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;
    using Recovery.Recoverable;

    [TestClass]
    public class CounterWithOptimisticSyncTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void NonConcurrentCounterOperations()
        {
            var sharedCounter = new Counter();
            var counter1 = new OptimisticSyncRecoverable(sharedCounter);
            counter1.BeginChanges();

            var counter2 = new OptimisticSyncRecoverable(sharedCounter);
            counter2.BeginChanges();

            counter1.Increase();
            counter1.Increase();

            counter1.CommitChanges();
            counter2.CommitChanges();

            Assert.AreEqual(2, counter1.Value);
            Assert.AreEqual(0, counter2.Value);
            Assert.AreEqual(2, sharedCounter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void ConflictingCounterOperation()
        {
            var sharedCounter = new Counter();
            var counter1 = new OptimisticSyncRecoverable(sharedCounter);
            var counter2 = new OptimisticSyncRecoverable(sharedCounter);


            counter1.Increase();
            counter2.Increase();

            Assert.AreEqual(1, sharedCounter.Value);
        }

    }
}
