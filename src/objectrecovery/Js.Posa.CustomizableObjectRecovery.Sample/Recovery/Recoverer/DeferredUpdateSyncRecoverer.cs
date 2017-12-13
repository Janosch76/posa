namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using RecoveryPoint;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeferredUpdateSyncRecoverer<T> : Recoverer<T> 
    {
        public DeferredUpdateSyncRecoverer(RecoveryPoint<T>.Factory recoveryPointFactory, T current)
            : base(recoveryPointFactory, current)
        {
        }

        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.current = recoveryPoint.Redo(this.current);
        }

        protected override T whichObject(T current, T obj)
        {
            return obj;
        }
    }
}
