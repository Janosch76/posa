namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;
    using Js.Posa.CommandProcessor.Sample.Model;

    public class EvalCommand : Command
    {
        private readonly Calculator calculator;

        public EvalCommand(Calculator calculator)
            : base(CommandType.Normal)
        {
            this.calculator = calculator;
        }

        public override string Name
        {
            get { return "EVAL"; }
        }

        public override void Execute()
        {
            this.calculator.Eval();
        }
    }
}