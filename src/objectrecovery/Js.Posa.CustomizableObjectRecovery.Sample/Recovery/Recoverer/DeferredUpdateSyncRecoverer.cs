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
        public DeferredUpdateSyncRecoverer(T current)
            : base(current)
        {
        }

        public override void Undo(IRecoveryPoint<T> recoveryPoint)
        {
        }

        public override void Redo(IRecoveryPoint<T> recoveryPoint)
        {
            this.current = recoveryPoint.Redo(this.current);
        }

        protected override T whichObject(T current, T obj)
        {
            return obj;
        }
    }
}
