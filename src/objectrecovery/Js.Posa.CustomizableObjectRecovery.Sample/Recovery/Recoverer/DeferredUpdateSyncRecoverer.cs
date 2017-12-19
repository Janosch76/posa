namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Model;
    using RecoveryPoint;

    public class DeferredUpdateSyncRecoverer<T> : Recoverer<T> 
        where T:IVersioned
    {
        public DeferredUpdateSyncRecoverer(T current) 
            : base(current)
        {
        }

        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            recoveryPoint.Redo(this.current);
        }

        protected override T whichObject(T obj)
        {
            return obj;
        }
    }
}
