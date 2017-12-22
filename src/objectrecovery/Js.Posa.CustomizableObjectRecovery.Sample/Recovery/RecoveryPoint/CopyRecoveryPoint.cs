namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    /// <summary>
    /// A copying recovery point.
    /// </summary>
    /// <typeparam name="T">The type of recoverable objects.</typeparam>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint.RecoveryPoint{T}" />
    public class CopyRecoveryPoint<T> : RecoveryPoint<T>
        where T : ICloneable
    {
        private T copy;

        /// <summary>
        /// Gets a factory for <see cref="CopyRecoveryPoint{T}"/> objects.
        /// </summary>
        public static IFactory Factory
        {
            get { return new CopyRecoveryPointFactory(); }
        }

        /// <summary>
        /// Initializes the recovery point from the given current object.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// Returns the working instance, typically the given
        /// current object or a working copy.
        /// </returns>
        public override T Prepare(T current)
        {
            this.copy = (T)current.Clone();
            return copy;
        }

        /// <summary>
        /// Redo changes from the given current  instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// The updated working instance.
        /// </returns>
        public override T Redo(T current)
        {
            return SwapWithCopy(current);
        }

        /// <summary>
        /// Undo changes in the given current instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// The updated working instance.
        /// </returns>
        public override T Undo(T current)
        {
            return SwapWithCopy(current);
        }

        private T SwapWithCopy(T current)
        {
            T obj = this.copy;
            this.copy = current;
            return obj;
        }

        private class CopyRecoveryPointFactory : IFactory
        {
            public RecoveryPoint<T> Prepare(T obj)
            {
                var rp = new CopyRecoveryPoint<T>();
                rp.Prepare(obj);
                return rp;
            }
        }
    }
}
