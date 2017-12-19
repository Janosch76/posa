namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;
    using Model;

    public class OptimisticSyncRecoverable
    {
        private readonly Recoverer<Counter> recoverer;
        private readonly RecoveryPoint<Counter>.Factory recoveryPointFactory;
        private Counter instance;
        private RecoveryPoint<Counter> initial;

        public OptimisticSyncRecoverable()
            : this(new Counter())
        {
        }

        public OptimisticSyncRecoverable(Counter instance) 
        {
            this.recoverer = new DeferredUpdateSyncRecoverer<Counter>(instance);
            this.recoveryPointFactory = CopyRecoveryPoint<Counter>.Factory;

            this.instance = instance;
        }

        public int Value
        {
            get { return this.instance.Value; }
        }

        public void BeginChanges()
        {
            var rp = this.recoveryPointFactory.Prepare(this.instance);
            this.initial = rp;
            this.instance = this.recoverer.Prepare(rp);
        }

        public void CommitChanges()
        {
            if (NoConcurrencyConflict())
            {
                this.recoverer.Redo(this.initial);
            }
        }

        public void Increase()
        {
            this.instance.Increase();
        }

        public void Reset()
        {
            this.instance.Increase();
        }

        private bool NoConcurrencyConflict()
        {
            // TODO
            return true;

            //var currentVersion = (this.recoverer as DeferredUpdateSyncRecoverer<Counter>).CurrentVersion;
            //return this.Instance.Version.Equals(currentVersion);
        }
    }
}