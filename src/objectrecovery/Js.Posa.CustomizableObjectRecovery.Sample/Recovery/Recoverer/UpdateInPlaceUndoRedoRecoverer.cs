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
            this.current = recoveryPoint.Undo(this.current);
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.current = recoveryPoint.Redo(this.current);
        }

        protected override T whichObject(T obj)
        {
            return this.current;
        }
    }
}
