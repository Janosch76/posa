namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class AddCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        public AddCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "ADD"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.Plus();
        }
    }
}
