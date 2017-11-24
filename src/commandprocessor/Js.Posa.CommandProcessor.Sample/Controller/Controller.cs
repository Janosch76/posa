namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System.Collections.Generic;
    using System.Linq;
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Controller 
    /// </summary>
    public class Controller
    {
        private readonly Calculator calculator;
        private readonly CommandProcessor commandProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        public Controller()
        {
            this.calculator = new Calculator();
            this.commandProcessor = new CommandProcessor();
        }

        /// <summary>
        /// Gets the calculation result.
        /// </summary>
        public decimal Result
        {
            get { return this.calculator.Result; }
        }

        /// <summary>
        /// Gets a string representation of the calculator state.
        /// </summary>
        public string State
        {
            get { return this.calculator.State; }
        }

        /// <summary>
        /// Gets a value indicating whether the undo action is possible.
        /// </summary>
        public bool UndoEnabled
        {
            get { return this.commandProcessor.UndoEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether the redo action is possible.
        /// </summary>
        public bool RedoEnabled
        {
            get { return this.commandProcessor.RedoEnabled; }
        }

        /// <summary>
        /// Gets the names of commands in the undo command list.
        /// </summary>
        public List<string> UndoCommands
        {
            get { return this.commandProcessor.UndoCommands.ToList(); }
        }

        /// <summary>
        /// Gets the names of commands in the redo command list.
        /// </summary>
        public List<string> RedoCommands
        {
            get { return this.commandProcessor.RedoCommands.ToList(); }
        }

        /// <summary>
        /// Handles the Undo button pressed event.
        /// </summary>
        public void UndoButtonPressed()
        {
            Command undoCommand = this.commandProcessor.GetUndoCommand;
            this.commandProcessor.ExecuteCommand(undoCommand);
        }

        /// <summary>
        /// Handles the Redo button pressed event.
        /// </summary>
        public void RedoButtonPressed()
        {
            Command redoCommand = this.commandProcessor.GetRedoCommand;
            this.commandProcessor.ExecuteCommand(redoCommand);
        }

        /// <summary>
        /// Handles the Clear button pressed event.
        /// </summary>
        public void ClearButtonPressed()
        {
            Command clearCommand = new ClearCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(clearCommand);
        }

        public void ValueEntered(decimal value)
        {
            Command setValueCommand = new EnterValueCommand(this.calculator, value);
            this.commandProcessor.ExecuteCommand(setValueCommand);
        }

        public void AddButtonPressed(decimal value)
        {
            Command addCommand = new AddCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(addCommand);
        }

        public void RecipButtonPressed()
        {
            Command recipCommand = new ReciprocalCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(recipCommand);
        }
    }
}
