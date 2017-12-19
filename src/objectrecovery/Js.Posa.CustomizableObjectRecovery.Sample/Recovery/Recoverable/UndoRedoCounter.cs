namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using Model;

    /// <summary>
    /// Recovery interface for <see cref="Counter"/> objects, providing user undo/redo.
    /// </summary>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable.UndoRedoRecoverable{Js.Posa.CustomizableObjectRecovery.Sample.Model.Counter}" />
    public class UndoRedoCounter : UndoRedoRecoverable<Counter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCounter"/> class.
        /// </summary>
        public UndoRedoCounter()
            : this(new Counter())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCounter"/> class.
        /// </summary>
        /// <param name="obj">The underlying <see cref="Counter"/> instance.</param>
        public UndoRedoCounter(Counter obj) 
            : base(obj)
        {
        }

        /// <summary>
        /// Gets the counter value.
        /// </summary>
        public int Value
        {
            get { return this.Instance.Value; }
        }

        /// <summary>
        /// Increases the counter value.
        /// </summary>
        public void Increase()
        {
            var rp = PrepareRecoveryPoint();
            this.Instance.Increase();
            AddRecoveryPointToHistory(rp);
        }

        /// <summary>
        /// Resets the counter value.
        /// </summary>
        public void Reset()
        {
            var rp = PrepareRecoveryPoint();
            this.Instance.Reset();
            AddRecoveryPointToHistory(rp);
        }
    }
}
