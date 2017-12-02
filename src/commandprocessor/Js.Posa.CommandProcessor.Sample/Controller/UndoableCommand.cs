namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    /// <summary>
    /// Base class containing generic code for undoable commands.
    /// </summary>
    /// <typeparam name="T">The state type of the object on which the command operates.</typeparam>
    /// <seealso cref="Js.Posa.CommandProcessor.Sample.Controller.Command" />
    public abstract class UndoableCommand<T> : Command
        where T : IMemorable<T>
    {
        private readonly T provider;
        private IMemento<T> memento;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoableCommand{T}"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public UndoableCommand(T provider) 
            : base(CommandType.Undoable)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            this.memento = this.provider.CreateMemento();
        }

        /// <summary>
        /// Reverses the effect of command execution.
        /// </summary>
        public override void Undo()
        {
            this.memento.Set(this.provider);
        }
    }
}
