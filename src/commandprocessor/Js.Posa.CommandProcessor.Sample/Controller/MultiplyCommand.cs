namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class MultiplyCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        public MultiplyCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "MULTIPLY"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.Times();
        }
    }
}