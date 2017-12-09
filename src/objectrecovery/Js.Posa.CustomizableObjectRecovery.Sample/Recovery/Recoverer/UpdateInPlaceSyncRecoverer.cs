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

        public override void Undo(IRecoveryPoint<T> recoveryPoint)
        {
            this.current = recoveryPoint.Undo(this.current);
        }

        public override void Redo(IRecoveryPoint<T> recoveryPoint)
        {
        }

        protected override T whichObject(T current, T obj)
        {
            return this.current;
        }
    }
}
