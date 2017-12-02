namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// A command to evaluate the current computation on the calculator state.
    /// </summary>
    /// <seealso cref="Js.Posa.CommandProcessor.Sample.Controller.Command" />
    public class EvalCommand : Command
    {
        private readonly Calculator calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvalCommand"/> class.
        /// </summary>
        /// <param name="calculator">The calculator.</param>
        public EvalCommand(Calculator calculator)
            : base(CommandType.Normal)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public override string Name
        {
            get { return "EVAL"; }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            this.calculator.Eval();
        }
    }
}