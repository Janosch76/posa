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


    }
}
