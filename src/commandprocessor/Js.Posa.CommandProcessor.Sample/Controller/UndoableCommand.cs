namespace Js.Posa.CommandProcessor.Sample.Controller
{
    using Js.Posa.CommandProcessor.Sample.Model;

    public abstract class UndoableCommand<T> : Command
        where T : IMemorable<T>
    {
        private readonly T provider;
        private IMemento<T> memento;

        public UndoableCommand(T provider) 
            : base(CommandType.Undoable)
        {
            this.provider = provider;
        }

        public override void Execute()
        {
            this.memento = this.provider.CreateMemento();
        }

        public override void Undo()
        {
            this.memento.Set(this.provider);
        }
    }
}
