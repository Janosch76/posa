namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    /// <summary>
    /// Recovery point signature. Holds the object-specific part of an
    /// algorithm for object recovery.
    /// </summary>
    /// <typeparam name="T">The type of recoverable object.</typeparam>
    public abstract class RecoveryPoint<T>
    {
        /// <summary>
        /// Signature for <see cref="RecoveryPoint{T}"/> factory objects.
        /// </summary>
        public interface IFactory
        {
            /// <summary>
            /// Prepares a new recovery point for the specified object.
            /// </summary>
            /// <param name="obj">The current object.</param>
            /// <returns>Returns a new recovery point.</returns>
            RecoveryPoint<T> Prepare(T obj);
        }

        /// <summary>
        /// Initializes the recovery point from the given current object.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>Returns the working instance, typically the given 
        /// current object or a working copy.</returns>
        public abstract T Prepare(T current);

        /// <summary>
        /// When overridden in a derived class, undo changes in the given 
        /// current  instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>The updated working instance.</returns>
        public abstract T Undo(T current);

        /// <summary>
        /// When overridden in a derived class, redo changes from the given 
        /// current  instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>The updated working instance.</returns>
        public abstract T Redo(T current);
    }
}