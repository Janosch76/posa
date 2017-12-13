namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using Recoverer;
    using RecoveryPoint;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Recoverable<T> where T: ICloneable
    {
        protected readonly Recoverer<T> recoverer;
        protected readonly Stack<RecoveryPoint<T>> pastRecoveryPoints;
        protected readonly Stack<RecoveryPoint<T>> futureRecoveryPoints;

        public Recoverable(T obj)
        {
            var recoveryPointFactory = CopyRecoveryPoint<T>.Factory;
            this.recoverer = new UpdateInPlaceUndoRedoRecoverer<T>(recoveryPointFactory, obj);
            this.pastRecoveryPoints = new Stack<RecoveryPoint<T>>();
            this.futureRecoveryPoints = new Stack<RecoveryPoint<T>>();
        }

        public void Undo()
        {
            if (!this.pastRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.pastRecoveryPoints.Pop();
            this.recoverer.Undo(rp);
            this.futureRecoveryPoints.Push(rp);
        }

        public void Redo()
        {
            if (!this.futureRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.futureRecoveryPoints.Pop();
            this.recoverer.Redo(rp);
            this.pastRecoveryPoints.Push(rp);
        }
    }
}
