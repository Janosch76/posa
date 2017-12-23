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

        /// <summary>
        /// Undo the changes done to a specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
            this.Current = recoveryPoint.Undo(this.Current);
        }

        /// <summary>
        /// Redo the changes done to a specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.Current = recoveryPoint.Redo(this.Current);
        }

        /// <summary>
        /// Determines whether to work
        /// on the current object or a copy.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The current working instance.
        /// </returns>
        protected override T WhichObject(T obj)
        {
            return this.Current;
        }
    }
}
