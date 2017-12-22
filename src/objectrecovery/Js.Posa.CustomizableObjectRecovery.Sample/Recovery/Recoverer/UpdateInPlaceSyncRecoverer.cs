namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using RecoveryPoint;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpdateInPlaceSyncRecoverer<T> : Recoverer<T>
    {
        public UpdateInPlaceSyncRecoverer(T current)
            : base(current)
        {
        }

        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
             this.Current = recoveryPoint.Undo(this.Current);
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
        }

        protected override T WhichObject(T obj)
        {
            return this.Current;
        }
    }
}
