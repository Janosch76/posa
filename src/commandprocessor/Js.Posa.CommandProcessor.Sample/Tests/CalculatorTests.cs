namespace Js.Posa.CommandProcessor.Sample.Tests
{
    using Js.Posa.CommandProcessor.Sample.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// A collection of unit tests for the <see cref="Calculator"/> class.
    /// </summary>
    [TestClass]
    public class CalulatorTests : TestBase
    {
        [UnitTest]
        [TestMethod]
        public void SimpleCalculationResult()
        {
            var calculator = new Calculator();
            calculator.EnterValue(5);

            var result = calculator.Eval();

            Assert.AreEqual(5.0m, result);
        }

        [UnitTest]
        [TestMethod]
        public void SimpleCalculationDisplay()
        {
            var calculator = new Calculator();
            calculator.EnterValue(5);

            var result = calculator.State;

            Assert.AreEqual("5", result);
        }

        [UnitTest]
        [TestMethod]
        public void CalculatorStateReset()
        {
            var calculator = new Calculator();
            calculator.EnterValue(5);
            calculator.Clear();

            var result = calculator.Eval();

            Assert.AreEqual(0.0m, result);
        }

        [UnitTest]
        [TestMethod]
        public void ComplexCalculationDisplay()
        {
            var calculator = new Calculator();
            calculator.EnterValue(5);
            calculator.Plus();
            calculator.EnterValue(2);
            calculator.Times();
            calculator.OpenParenthesis();
            calculator.EnterValue(3);
            calculator.Minus();
            calculator.EnterValue(1);
            calculator.CloseParenthesis();

            var result = calculator.State;

            Assert.AreEqual("5+2*(3-1)", result);
        }

        [UnitTest]
        [TestMethod]
        public void ComplexCalculationResult()
        {
            var calculator = new Calculator();
            calculator.EnterValue(5);
            calculator.Plus();
            calculator.EnterValue(2);
            calculator.Times();
            calculator.OpenParenthesis();
            calculator.EnterValue(3);
            calculator.Minus();
            calculator.EnterValue(1);
            calculator.CloseParenthesis();

            var result = calculator.Eval();

            Assert.AreEqual(9, result);
        }
    }
}
