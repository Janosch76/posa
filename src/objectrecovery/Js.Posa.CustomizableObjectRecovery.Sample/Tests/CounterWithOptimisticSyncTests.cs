namespace Js.Posa.CustomizableObjectRecovery.Sample.Tests
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CounterWithOptimisticSyncTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void CounterOperationsOnWorkingCopy()
        {
            var sharedCounter = new Counter();
            using (var counter = new OptimisticSyncRecoverable(sharedCounter))
            {
                counter.Increase();
                counter.Increase();

                Assert.AreEqual(2, counter.Value);
            }
        }

        [UnitTest]
        [TestMethod]
        public void UncommittedCounterOperations()
        {
            var sharedCounter = new Counter();
            using (var counter = new OptimisticSyncRecoverable(sharedCounter))
            {
                counter.Increase();
                counter.Increase();
            }

            // modifications not committed
            Assert.AreEqual(0, sharedCounter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void NonConcurrentCounterOperations()
        {
            var sharedCounter = new Counter();
            using (var counter = new OptimisticSyncRecoverable(sharedCounter))
            {
                counter.Increase();
                counter.Increase();

                counter.CommitChanges();
            }

            Assert.AreEqual(2, sharedCounter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void ConflictingCounterOperation()
        {
            var sharedCounter = new Counter();
            using (var counter1 = new OptimisticSyncRecoverable(sharedCounter))
            {
                counter1.Increase();
                counter1.Increase();

                sharedCounter.Increase();

                AssertThrows<Exception>(() =>
                {
                    counter1.CommitChanges();
                });
            }
        }
    }
}
