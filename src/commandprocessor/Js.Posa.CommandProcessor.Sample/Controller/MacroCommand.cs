﻿namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;
    using System.Collections.Generic;

    public class MacroCommand : Command
    {
        private readonly string macroName;
        private readonly List<Command> commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="MacroCommand"/> class.
        /// </summary>
        /// <param name="macroName">Name of the macro.</param>
        public MacroCommand(string macroName)
            : base(CommandType.NoChange)
        {
            this.macroName = macroName;
            this.commands = new List<Command>();
        }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public override string Name
        {
            get { return this.macroName; }
        }

        /// <summary>
        /// Adds a command to the macro.
        /// </summary>
        /// <param name="command">The command to add.</param>
        public void AddCommand(Command command)
        {
            this.commands.Add(command);

            if (command.Type == CommandType.Normal)
            {
                Type = CommandType.Normal;
            }
            else if (command.Type == CommandType.Undoable && Type == CommandType.NoChange)
            {
                Type = CommandType.Undoable;
            }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            foreach (var command in this.commands)
            {
                command.Execute();
            }
        }

        /// <summary>
        /// Reverses the effect of command execution.
        /// </summary>
        public override void Undo()
        {
            if (Type == CommandType.Normal)
            {
                throw new InvalidOperationException();
            }

            foreach (var command in this.commands)
            {
                command.Undo();
            }
        }
    }
}
