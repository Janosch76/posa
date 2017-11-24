namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class EnterValueCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;
        private readonly decimal value;

        public EnterValueCommand(Calculator calculator, decimal value) 
            : base(calculator)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public override string Name
        {
            get { return "SET"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.EnterValue(value);
        }
    }
}
