 namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// Holds the object-independent part of the recovery algorithm.
    /// </summary>
    /// <typeparam name="T">The type of recoverable object.</typeparam>
    public abstract class Recoverer<T> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recoverer{T}"/> class.
        /// </summary>
        /// <param name="current">The current recoverable object.</param>
        protected Recoverer(T current)
        {
            this.Current = current;
        }

        /// <summary>
        /// Gets or sets the current working instance.
        /// </summary>
        protected T Current { get; set; }

        /// <summary>
        /// Prepares the specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        /// <returns>Returns the working instance.</returns>
        public virtual T Prepare(RecoveryPoint<T> recoveryPoint)
        {
            T obj = recoveryPoint.Prepare(this.Current);
            return WhichObject(obj);
        }

        /// <summary>
        /// When overridden in a derived class, undo the changes done to 
        /// a specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public abstract void Undo(RecoveryPoint<T> recoveryPoint);

        /// <summary>
        /// When overridden in a derived class, redo the changes done to 
        /// a specified recovery point.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point.</param>
        public abstract void Redo(RecoveryPoint<T> recoveryPoint);

        /// <summary>
        /// When overridden in a derived class, determines whether to work 
        /// on the current object or a copy.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The current working instance.</returns>
        protected abstract T WhichObject(T obj);
    }
}
