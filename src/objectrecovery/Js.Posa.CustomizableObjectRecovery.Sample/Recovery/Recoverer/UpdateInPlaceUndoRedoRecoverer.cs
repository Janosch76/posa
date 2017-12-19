namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RecoveryPoint;

    public class UpdateInPlaceUndoRedoRecoverer<T> : Recoverer<T>
    {
        private readonly Stack<RecoveryPoint<T>> pastRecoveryPoints;
        private readonly Stack<RecoveryPoint<T>> futureRecoveryPoints;

        public UpdateInPlaceUndoRedoRecoverer(RecoveryPoint<T>.Factory recoveryPointFactory)
            : base(recoveryPointFactory)
        {
            this.pastRecoveryPoints = new Stack<RecoveryPoint<T>>();
            this.futureRecoveryPoints = new Stack<RecoveryPoint<T>>();
        }

        public override T Undo(T current)
        {
            if (!this.pastRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.pastRecoveryPoints.Pop();
            var previous = rp.Undo(current);
            this.futureRecoveryPoints.Push(rp);
            return previous;
        }

        public override T Redo(T current)
        {
            if (!this.futureRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.futureRecoveryPoints.Pop();
            var next = rp.Redo(current);
            this.pastRecoveryPoints.Push(rp);
            return next;
        }

        protected override void OnRecoveryPointPrepared(RecoveryPoint<T> recoveryPoint)
        {
            base.OnRecoveryPointPrepared(recoveryPoint);

            this.pastRecoveryPoints.Push(recoveryPoint);
            this.futureRecoveryPoints.Clear();
        }

        protected override T whichObject(T current, T obj)
        {
            return current;
        }
    }
}
