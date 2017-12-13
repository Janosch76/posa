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
        protected RecoveryPoint<T>.Factory recoveryPointFactory;

        public Recoverer(RecoveryPoint<T>.Factory recoveryPointFactory, T current)
        {
            this.recoveryPointFactory = recoveryPointFactory;
            this.current = current;
        }

        public T Current
        {
            get { return this.current; }
        }

        public virtual RecoveryPoint<T> Prepare()
        {
            RecoveryPoint<T> recoveryPoint = this.recoveryPointFactory.Prepare(this.current);
            this.current = whichObject(this.current, recoveryPoint.Value);
            return recoveryPoint;
        }

        public abstract void Undo(RecoveryPoint<T> recoveryPoint);

        public abstract void Redo(RecoveryPoint<T> recoveryPoint);

        protected abstract T whichObject(T current, T obj);
    }
}
