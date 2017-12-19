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
        protected RecoveryPoint<T>.Factory recoveryPointFactory;
        protected RecoveryPoint<T> prepared;

        protected Recoverer(RecoveryPoint<T>.Factory recoveryPointFactory)
        {
            this.recoveryPointFactory = recoveryPointFactory;
        }

        public virtual T PrepareRecoveryPoint(T current)
        {
            RecoveryPoint<T> recoveryPoint = this.recoveryPointFactory.Prepare(current);
            OnRecoveryPointPrepared(recoveryPoint);
            return whichObject(current, recoveryPoint.Value);
        }

        protected virtual void OnRecoveryPointPrepared(RecoveryPoint<T> recoveryPoint)
        {
        }

        public abstract T Undo(T current);

        public abstract T Redo(T current);

        protected abstract T whichObject(T current, T obj);
    }
}
