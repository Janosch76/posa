namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Command to push a value onto the calculator computation stack.
    /// </summary>
    /// <seealso cref="Js.Posa.CommandProcessor.Sample.Controller.Command" />
    public class SetValueCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;
        private readonly decimal value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetValueCommand"/> class.
        /// </summary>
        /// <param name="calculator">The calculator.</param>
        /// <param name="value">The value.</param>
        public SetValueCommand(Calculator calculator, decimal value) 
            : base(calculator)
        {
            this.calculator = calculator;
            this.value = value;
        }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public override string Name
        {
            get { return $"SET {value.ToString("0.##")}"; }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.calculator.EnterValue(value);
        }
    }
}
