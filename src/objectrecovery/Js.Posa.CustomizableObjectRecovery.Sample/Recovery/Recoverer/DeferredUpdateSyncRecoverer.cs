namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using RecoveryPoint;

    public class DeferredUpdateSyncRecoverer<T> : Recoverer<T> 
    {
        private T workingCopy;

        public DeferredUpdateSyncRecoverer(T current) 
            : base(current)
        {
        }

        public T WorkingCopy
        {
            get { return this.workingCopy; }
        }

        public override void Undo(RecoveryPoint<T> recoveryPoint)
        {
        }

        public override void Redo(RecoveryPoint<T> recoveryPoint)
        {
            this.workingCopy = recoveryPoint.Redo(this.workingCopy);
        }

        protected override T whichObject(T obj)
        {
            this.workingCopy = obj;
            return obj;
        }
    }
}
