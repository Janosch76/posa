namespace Js.Posa.CommandProcessor.Sample.Tests
{
    using Js.Posa.CommandProcessor.Sample.Controller;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ControllerTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void SimpleCalculationResult()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.EvalButtonPressed();

            var result = controller.Result;

            Assert.AreEqual(5.0m, result);
        }

        [UnitTest]
        [TestMethod]
        public void SimpleCalculationDisplay()
        {
            var controller = new Controller();
            controller.ValueEntered(5);

            var result = controller.State;

            Assert.AreEqual("5", result);
        }

        [UnitTest]
        [TestMethod]
        public void ComplexCalculationResult()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);
            controller.TimesButtonPressed();
            controller.OpenParenthesisPressed();
            controller.ValueEntered(3);
            controller.MinusButtonPressed();
            controller.ValueEntered(1);
            controller.CloseParenthesisPressed();
            controller.EvalButtonPressed();

            var result = controller.Result;

            Assert.AreEqual(9, result);
        }

        [UnitTest]
        [TestMethod]
        public void UndoEnabledRedoDisabled()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);

            Assert.AreEqual(true, controller.UndoEnabled);
            Assert.AreEqual(false, controller.RedoEnabled);
        }

        [UnitTest]
        [TestMethod]
        public void UndoEnabledRedoEnabled()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);
            controller.UndoButtonPressed();

            Assert.AreEqual(true, controller.UndoEnabled);
            Assert.AreEqual(true, controller.RedoEnabled);
        }

        [UnitTest]
        [TestMethod]
        public void UndoDisabledRedoEnabled()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);
            controller.UndoButtonPressed();
            controller.UndoButtonPressed();
            controller.UndoButtonPressed();

            Assert.AreEqual(false, controller.UndoEnabled);
            Assert.AreEqual(true, controller.RedoEnabled);
        }

        [UnitTest]
        [TestMethod]
        public void CalculationWithUndo()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);
            controller.TimesButtonPressed();
            controller.UndoButtonPressed();
            controller.UndoButtonPressed();
            controller.ValueEntered(3);
            controller.EvalButtonPressed();

            var result = controller.Result;

            Assert.AreEqual(8, result);
        }

        [UnitTest]
        [TestMethod]
        public void CalculationWithUndoRedo()
        {
            var controller = new Controller();
            controller.ValueEntered(5);
            controller.PlusButtonPressed();
            controller.ValueEntered(2);
            controller.UndoButtonPressed();
            controller.UndoButtonPressed();
            controller.RedoButtonPressed();
            controller.RedoButtonPressed();
            controller.EvalButtonPressed();

            var result = controller.Result;

            Assert.AreEqual(7, result);
        }

    }
}
