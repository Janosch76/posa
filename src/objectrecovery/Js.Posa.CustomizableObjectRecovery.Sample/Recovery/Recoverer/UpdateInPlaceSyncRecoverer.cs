namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

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
