namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;
    using Recovery.Recoverable;
    using Recovery.Recoverer;
    using Recovery.RecoveryPoint;

    // recovery interface
    public class CounterWithUndoRedo : Recoverable<Counter>
    {
        public CounterWithUndoRedo()
            : this(new Counter())
        {
        }

        public CounterWithUndoRedo(Counter obj) 
            : base(obj, new UpdateInPlaceUndoRedoRecoverer<Counter>(CopyRecoveryPoint<Counter>.Factory))
        {
        }

        public int Value
        {
            get { return this.Current.Value; }
        }

        public void Increase()
        {
            Prepare();
            this.Current.Increase();
        }

        public void Reset()
        {
            Prepare();
            this.Current.Reset();
        }

        public new void Undo()
        {
            base.Undo();
        }

        public new void Redo()
        {
            base.Redo();
        }
    }
}
