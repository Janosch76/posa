namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Addition command
    /// </summary>
    /// <seealso cref="Js.Posa.CommandProcessor.Sample.Controller.Command" />
    public class AddCommand : UndoableCommand<Calculator>
    {
        private readonly Calculator calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class.
        /// </summary>
        /// <param name="calculator">The calculator.</param>
        public AddCommand(Calculator calculator) 
            : base(calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public override string Name
        {
            get { return "ADD"; }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.calculator.Plus();
        }
    }
}
