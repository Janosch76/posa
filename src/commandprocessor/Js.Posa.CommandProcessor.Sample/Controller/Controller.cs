namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Controller class.
    /// </summary>
    public class Controller
    {
        private readonly Calculator calculator;
        private readonly CommandProcessor commandProcessor;
        private readonly Dictionary<string, MacroCommand> macros;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        public Controller()
        {
            this.calculator = new Calculator();
            this.commandProcessor = new CommandProcessor();
            this.macros = new Dictionary<string, MacroCommand>();
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

        /// <summary>
        /// Handles the value entered event.
        /// </summary>
        /// <param name="value">The value.</param>
        public void ValueEntered(decimal value)
        {
            Command setValueCommand = new SetValueCommand(this.calculator, value);
            this.commandProcessor.ExecuteCommand(setValueCommand);
        }

        /// <summary>
        /// Handles the equals button pressed event.
        /// </summary>
        public void EvalButtonPressed()
        {
            Command evalCommand = new EvalCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(evalCommand);
        }

        /// <summary>
        /// Handles the opening parenthesis pressed event.
        /// </summary>
        public void OpenParenthesisPressed()
        {
            Command openParenthesisCommand = new OpenParenthesisCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(openParenthesisCommand);
        }

        /// <summary>
        /// Handles the closing parenthesis pressed event.
        /// </summary>
        public void CloseParenthesisPressed()
        {
            Command closeParenthesisCommand = new CloseParenthesisCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(closeParenthesisCommand);
        }

        /// <summary>
        /// Handles the plus button pressed event.
        /// </summary>
        public void PlusButtonPressed()
        {
            Command addCommand = new AddCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(addCommand);
        }

        /// <summary>
        /// Handles the minus button pressed event.
        /// </summary>
        public void MinusButtonPressed()
        {
            Command subtractCommand = new SubtractCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(subtractCommand);
        }

        /// <summary>
        /// Handles the times button pressed event.
        /// </summary>
        public void TimesButtonPressed()
        {
            Command multiplyCommand = new MultiplyCommand(this.calculator);
            this.commandProcessor.ExecuteCommand(multiplyCommand);
        }

        /// <summary>
        /// Handles the start macro button pressed event.
        /// </summary>
        public void StartMacroRecording()
        {
            this.commandProcessor.StartMacroRecording();
        }

        /// <summary>
        /// Handles the stop macro recording button pressed event, and
        /// saves the recorded macro under a given macro name.
        /// </summary>
        /// <param name="name">The macro name.</param>
        public void SaveRecordedMacroAs(string name)
        {
            var macro = this.commandProcessor.StopMacroRecording();
            macro.Rename(name);
            this.macros[name] = macro;
        }

        /// <summary>
        /// Executes the macro command with the given name.
        /// </summary>
        /// <param name="name">The macro name.</param>
        public void RunMacro(string name)
        {
            if (!this.macros.ContainsKey(name))
            {
                throw new Exception($"Unknown macro '{name}'.");
            }

            this.commandProcessor.ExecuteCommand(this.macros[name]);
        }
    }
}
