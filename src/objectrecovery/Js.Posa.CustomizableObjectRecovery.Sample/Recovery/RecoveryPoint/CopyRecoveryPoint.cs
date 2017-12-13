namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    public class CopyRecoveryPoint<T> : RecoveryPoint<T> 
        where T: ICloneable
    {
        private T copy;

        public override T Value
        {
            get { return this.copy; }
        }

        public override void Prepare(T current)
        {
            this.copy = (T)current.Clone();
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
