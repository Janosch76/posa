namespace Js.Posa.CustomizableObjectRecovery.Sample.Tests
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CounterWithUndoRedoTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void CounterOperation()
        {
            var counter = new UndoRedoCounter(new Counter());

            counter.Increase();

            Assert.AreEqual(1, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterUndoOperation()
        {
            var counter = new UndoRedoCounter(new Counter());

            counter.Increase();
            counter.Undo();

            Assert.AreEqual(0, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterUndoRedoOperation()
        {
            var counter = new UndoRedoCounter(new Counter());

            counter.Increase();
            counter.Undo();
            counter.Redo();

            Assert.AreEqual(1, counter.Value);
        }

        [UnitTest]
        [TestMethod]
        public void CounterSequenceWithUndoRedo()
        {
            var counter = new UndoRedoCounter(new Counter());

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
