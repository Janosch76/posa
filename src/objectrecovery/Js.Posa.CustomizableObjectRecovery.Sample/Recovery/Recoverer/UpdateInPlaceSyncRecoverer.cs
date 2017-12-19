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
        public UpdateInPlaceSyncRecoverer(RecoveryPoint<T>.Factory recoveryPointFactory)
            : base(recoveryPointFactory)
        {
        }

        public override T Undo(T current)
        {
             return this.prepared.Undo(current);
        }

        public override T Redo(T current)
        {
            return current;
        }

        protected override T whichObject(T current, T obj)
        {
            return current;
        }
    }
}
