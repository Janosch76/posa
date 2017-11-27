﻿namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public class SetValueCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;
        private readonly decimal value;

        public SetValueCommand(Calculator calculator, decimal value) 
            : base(calculator)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public override string Name
        {
            get { return $"SET {value.ToString("0.##")}"; }
        }

        public override void Execute()
        {
            base.Execute();
            this.calculator.EnterValue(value);
        }
    }
}
