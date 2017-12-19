namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Model;
    using RecoveryPoint;
    using System;

    public class DeferredUpdateSyncRecoverer<T> : Recoverer<T> 
        where T:IVersioned
    {
        protected RecoveryPoint<T> recoveryPoint;

        public DeferredUpdateSyncRecoverer(RecoveryPoint<T>.Factory recoveryPointFactory)
            : base(recoveryPointFactory)
        {
        }

        public Guid CurrentVersion
        {
            get { return this.recoveryPoint.Value.Version; }
        }

        public override T Undo(T current)
        {
            return current;
        }

        public override T Redo(T current)
        {
            return recoveryPoint.Redo(current);
        }

        protected override void OnRecoveryPointPrepared(RecoveryPoint<T> recoveryPoint)
        {
            base.OnRecoveryPointPrepared(recoveryPoint);

            this.recoveryPoint = recoveryPoint;
        }

        protected override T whichObject(T current, T obj)
        {
            return obj;
        }
    }
}
