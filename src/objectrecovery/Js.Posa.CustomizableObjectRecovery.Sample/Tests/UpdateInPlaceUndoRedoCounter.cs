namespace Js.Posa.CustomizableObjectRecovery.Sample.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;

    [TestClass]
    public class UpdateInPlaceUndoRedoCounter : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void CounterOperation()
        {
            var counter = new RecoverableCounter(new Counter());

            counter.Increase();

            Assert.AreEqual(1, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterUndoOperation()
        {
            var counter = new RecoverableCounter(new Counter());

            counter.Increase();
            counter.Undo();

            Assert.AreEqual(0, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterUndoRedoOperation()
        {
            var counter = new RecoverableCounter(new Counter());

            counter.Increase();
            counter.Undo();
            counter.Redo();

            Assert.AreEqual(1, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterSequenceWithUndoRedo()
        {
            var counter = new RecoverableCounter(new Counter());

            counter.Increase();
            counter.Increase();
            counter.Undo();
            counter.Increase();
            counter.Reset();
            counter.Undo();
            counter.Redo();
            counter.Undo();
            counter.Redo();
            counter.Increase();

            Assert.AreEqual(1, counter.Value);
        }
    }
}
