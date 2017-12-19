namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    public class CounterWithOptimisticSync : Recoverable<Counter>
    {
        public CounterWithOptimisticSync()
            : this(new Counter())
        {
        }

        public CounterWithOptimisticSync(Counter obj) 
            : base(obj, new DeferredUpdateSyncRecoverer<Counter>(CopyRecoveryPoint<Counter>.Factory))
        {
        }

        public int Value
        {
            get { return this.Current.Value; }
        }

        public void Increase()
        {
            Prepare();
            this.Current.Increase();
            if (NoConcurrencyConflict())
            {
                this.recoverer.Redo(this.Current);
            }
        }

        public void Reset()
        {
            Prepare();
            this.Current.Reset();
            if (NoConcurrencyConflict())
            {
                this.recoverer.Redo(this.Current);
            }
        }

        private bool NoConcurrencyConflict()
        {
            var currentVersion = (this.recoverer as DeferredUpdateSyncRecoverer<Counter>).CurrentVersion;
            return this.Current.Version.Equals(currentVersion);
        }
    }
}