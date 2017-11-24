namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class ReciprocalCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        public ReciprocalCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "RECIP"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.Reciprocal();
        }
    }
}
