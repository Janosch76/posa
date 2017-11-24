namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using System;

    /// <summary>
    /// Command base class. Defines a uniform interface for command execution
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="type">The command type.</param>
        internal Command(CommandType type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the command type.
        /// </summary>
        public CommandType Type { get; protected set; }

        /// <summary>
        /// Gets the name of the command, as displayed for the undo/redo menu.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Reverses the effect of command execution.
        /// </summary>
        public virtual void Undo()
        {
            throw new InvalidOperationException();
        }
    }
}
