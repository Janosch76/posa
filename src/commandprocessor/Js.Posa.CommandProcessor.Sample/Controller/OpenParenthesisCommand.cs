namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    internal class OpenParenthesisCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        public OpenParenthesisCommand(Calculator calculator)
            : base(calculator)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "("; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.OpenParenthesis();
        }
    }
}
