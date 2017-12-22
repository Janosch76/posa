namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// The object-independent part of an undo-redo mechanism
    /// </summary>
    /// <typeparam name="T">The type of recoverable objects.</typeparam>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer.Recoverer{T}" />
    public class UpdateInPlaceUndoRedoRecoverer<T> : Recoverer<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInPlaceUndoRedoRecoverer{T}"/> class.
        /// </summary>
        /// <param name="current">The current recoverable object.</param>
        public UpdateInPlaceUndoRedoRecoverer(T current)
            : base(current)
        {
        }

        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
            this.Current = recoveryPoint.Undo(this.Current);
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.Current = recoveryPoint.Redo(this.Current);
        }

        protected override T WhichObject(T obj)
        {
            return this.Current;
        }
    }
}
