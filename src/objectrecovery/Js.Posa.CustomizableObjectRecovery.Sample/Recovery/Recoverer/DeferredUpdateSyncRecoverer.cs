namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// Implements a recovery strategy that uses a working copy and final synchronization
    /// on the original instance.
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer.Recoverer{T}" />
    public class DeferredUpdateSyncRecoverer<T> : Recoverer<T> 
    {
        private T workingCopy;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeferredUpdateSyncRecoverer{T}"/> class.
        /// </summary>
        /// <param name="current">The current recoverable object.</param>
        public DeferredUpdateSyncRecoverer(T current) 
            : base(current)
        {
        }

        /// <summary>
        /// Gets the working copy.
        /// </summary>
        public T WorkingCopy
        {
            get { return this.workingCopy; }
        }

        /// <summary>
        /// No op.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
        }

        /// <summary>
        /// When overridden in a derived class, redo the changes done to
        /// a specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.workingCopy = recoveryPoint.Redo(this.workingCopy);
        }

        /// <summary>
        /// Determines that the recovery strategy works on a copy.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The current working instance.
        /// </returns>
        protected override T WhichObject(T obj)
        {
            this.workingCopy = obj;
            return obj;
        }
    }
}
