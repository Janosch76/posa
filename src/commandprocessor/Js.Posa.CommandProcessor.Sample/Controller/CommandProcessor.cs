namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Activates command execution, and maintains command objects for Undo/Redo mechanism.
    /// </summary>
    public class CommandProcessor
    {
        private Stack<Command> doneStack;
        private Stack<Command> undoneStack;
        private MacroCommand macro;
        private bool macroRecordingInProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class.
        /// </summary>
        public CommandProcessor()
        {
            this.doneStack = new Stack<Command>();
            this.undoneStack = new Stack<Command>();
            this.macroRecordingInProgress = false;
        }

        /// <summary>
        /// Gets a value indicating whether the undo action is possible.
        /// </summary>
        public bool UndoEnabled
        {
            get { return this.doneStack.Any(); }
        }

        /// <summary>
        /// Gets a value indicating whether the redo action is possible.
        /// </summary>
        public bool RedoEnabled
        {
            get { return this.undoneStack.Any(); }
        }

        /// <summary>
        /// Gets the names of the commands in the undo command list.
        /// </summary>
        public IEnumerable<string> UndoCommands
        {
            get { return this.doneStack.Select(cmd => cmd.Name); }
        }

        /// <summary>
        /// Gets the names of the commands in the redo command list.
        /// </summary>
        public IEnumerable<string> RedoCommands
        {
            get { return this.undoneStack.Select(cmd => cmd.Name); }
        }

        /// <summary>
        /// Gets a command that provides access to undo mechanism of the command processor.
        /// </summary>
        public Command GetUndoCommand
        {
            get { return new UndoCommand(this); }
        }

        /// <summary>
        /// Gets a command that provides access to redo mechanism of the command processor.
        /// </summary>
        public Command GetRedoCommand
        {
            get { return new RedoCommand(this); }
        }

        /// <summary>
        /// Gets a value indicating whether starting macro recording is possible.
        /// </summary>
        public bool StartMacroRecordingEnabled
        {
            get { return !this.macroRecordingInProgress; }
        }

        /// <summary>
        /// Gets a value indicating whether stopping macro recording is possible.
        /// </summary>
        public bool StopMacroRecordingEnabled
        {
            get { return this.macroRecordingInProgress; }
        }

        /// <summary>
        /// Executes a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void ExecuteCommand(Command command)
        {
            command.Execute();

            switch (command.Type)
            {
                case CommandType.NoChange:
                    break;
                case CommandType.Undoable:
                    this.doneStack.Push(command);
                    this.undoneStack.Clear();
                    break;
                case CommandType.Normal:
                    this.doneStack.Clear();
                    this.undoneStack.Clear();
                    break;
            }

            if (this.macroRecordingInProgress)
            {
                this.macro.AddCommand(command);
            }
        }

        /// <summary>
        /// Starts the macro recording.
        /// </summary>
        public void StartMacroRecording()
        {
            if (this.macroRecordingInProgress)
            {
                throw new Exception("Macro recording already in progress.");
            }

            this.macroRecordingInProgress = true;
            this.macro = new MacroCommand("Macro 1");
        }

        /// <summary>
        /// Stops the macro recording.
        /// </summary>
        /// <returns>The recorded macro command.</returns>
        public Command StopMacroRecording()
        {
            if (!this.macroRecordingInProgress)
            {
                throw new Exception("Macro recording has not been started.");
            }

            this.macroRecordingInProgress = false;
            return this.macro;
        }

        private void UndoLastCommand()
        {
            if (!this.doneStack.Any())
            {
                throw new InvalidOperationException("No commands available to undo.");
            }

            Command command = this.doneStack.Pop();
            command.Undo();
            this.undoneStack.Push(command);
        }

        private void RedoLastUndoneCommand()
        {
            if (!this.undoneStack.Any())
            {
                throw new InvalidOperationException("No commands available to redo.");
            }

            Command command = this.undoneStack.Pop();
            ExecuteCommand(command);
        }

        private class UndoCommand : Command
        {
            private readonly CommandProcessor commandProcessor;

            public UndoCommand(CommandProcessor commandProcessor)
                : base(CommandType.NoChange)
            {
                this.commandProcessor = commandProcessor;
            }

            public override string Name
            {
                get { return "UNDO"; }
            }

            public override void Execute()
            {
                this.commandProcessor.UndoLastCommand();
            }
        }

        private class RedoCommand : Command
        {
            private readonly CommandProcessor commandProcessor;

            public RedoCommand(CommandProcessor commandProcessor)
                : base(CommandType.NoChange)
            {
                this.commandProcessor = commandProcessor;
            }

            public override string Name
            {
                get { return "REDO"; }
            }

            public override void Execute()
            {
                this.commandProcessor.RedoLastUndoneCommand();
            }
        }
    }
}
