namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// Holds the object-independent part of the recovery algorithm.
    /// </summary>
    /// <typeparam name="T">The type of recoverable object.</typeparam>
    public abstract class Recoverer<T> 
    {
        protected T current;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recoverer{T}"/> class.
        /// </summary>
        /// <param name="current">The current recoverable object.</param>
        protected Recoverer(T current)
        {
            this.current = current;
        }

        public virtual T Prepare(RecoveryPoint<T> recoveryPoint)
        {
            T obj = recoveryPoint.Prepare(this.current);
            return whichObject(obj);
        }

        public abstract void Undo(RecoveryPoint<T> recoveryPoint);

        public abstract void Redo(RecoveryPoint<T> recoveryPoint);

        protected abstract T whichObject(T obj);
    }
}
