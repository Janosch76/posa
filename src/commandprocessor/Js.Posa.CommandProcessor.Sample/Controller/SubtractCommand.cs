namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class SubtractCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        public SubtractCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "MINUS"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.Minus();
        }
    }
}