namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Subtraction command.
    /// </summary>
    /// <seealso cref="Js.Posa.CommandProcessor.Sample.Controller.Command" />
    public class SubtractCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractCommand"/> class.
        /// </summary>
        /// <param name="calculator">The calculator.</param>
        public SubtractCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public override string Name
        {
            get { return "MINUS"; }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.calculator.Minus();
        }
    }
}