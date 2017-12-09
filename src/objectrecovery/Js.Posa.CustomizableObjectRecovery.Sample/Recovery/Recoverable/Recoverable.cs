namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using Recoverer;
    using RecoveryPoint;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Recoverable<T>
    {
        protected readonly Recoverer<T> recoverer;
        protected readonly Stack<IRecoveryPoint<T>> pastRecoveryPoints;
        protected readonly Stack<IRecoveryPoint<T>> futureRecoveryPoints;

        public Recoverable(T obj)
        {
            this.recoverer = new UpdateInPlaceUndoRedoRecoverer<T>(obj);
            this.pastRecoveryPoints = new Stack<IRecoveryPoint<T>>();
            this.futureRecoveryPoints = new Stack<IRecoveryPoint<T>>();
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
