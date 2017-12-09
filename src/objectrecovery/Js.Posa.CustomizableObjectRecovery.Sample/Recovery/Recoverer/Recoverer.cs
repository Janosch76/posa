namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using RecoveryPoint;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Recoverer<T>
    {
        protected T current;

        public Recoverer(T current)
        {
            this.current = current;
        }

        public T Current
        {
            get { return this.current; }
        }

        public virtual IRecoveryPoint<T> Prepare(IRecoveryPoint<T> recoveryPoint)
        {
            T obj = recoveryPoint.Prepare(this.current);
            this.current = whichObject(this.current, obj);
            return recoveryPoint;
        }

        public abstract void Undo(IRecoveryPoint<T> recoveryPoint);

        public abstract void Redo(IRecoveryPoint<T> recoveryPoint);

        protected abstract T whichObject(T current, T obj);
    }
}
