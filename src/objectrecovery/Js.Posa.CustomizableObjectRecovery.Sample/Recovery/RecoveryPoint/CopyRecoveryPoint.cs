namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    /// <summary>
    /// A copying recovery point.
    /// </summary>
    /// <typeparam name="T">The type of recoverable objects.</typeparam>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint.RecoveryPoint{T}" />
    public class CopyRecoveryPoint<T> : RecoveryPoint<T> 
        where T: ICloneable
    {
        private T copy;

        /// <summary>
        /// Prepares the specified current.
        /// </summary>
        /// <param name="current">The current recoverable.</param>
        /// <returns></returns>
        public override T Prepare(T current)
        {
            this.copy = (T)current.Clone();
            return copy;
        }

        public override T Redo(T current)
        {
            return SwapWithCopy(current);
        }

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

        new public static Factory Factory
        {
            get { return new CopyRecoveryPointFactory(); }
        }

        private class CopyRecoveryPointFactory : Factory
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
