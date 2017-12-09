namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    public class CopyRecoveryPoint<T> : IRecoveryPoint<T> 
        where T: ICloneable
    {
        private T copy;

        public T Prepare(T current)
        {
            this.copy = (T)current.Clone();
            return this.copy;
        }

        public T Redo(T current)
        {
            return SwapWithCopy(current);
        }

        public T Undo(T current)
        {
            return SwapWithCopy(current);
        }

        private T SwapWithCopy(T current)
        {
            T obj = this.copy;
            this.copy = current;
            return obj;
        }
    }
}
