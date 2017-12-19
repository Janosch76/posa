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
        private T current;

        public Recoverable(T current, Recoverer<T> recoverer)
        {
            this.current = current;
            this.recoverer = recoverer;
        }

        protected T Current
        {
            get { return this.current; }
        }

        protected void Undo()
        {
            this.current = this.recoverer.Undo(this.current);
        }

        protected void Redo()
        {
            this.current = this.recoverer.Redo(this.current);
        }

        protected void Prepare()
        {
            this.current = this.recoverer.PrepareRecoveryPoint(this.current);
        }
    }
}
