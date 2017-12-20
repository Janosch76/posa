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
        private RecoveryPoint<Counter> recoveryPoint;
        private Guid initialVersion;

        public OptimisticSyncRecoverable()
            : this(new Counter())
        {
        }

        public OptimisticSyncRecoverable(Counter instance) 
        {
            this.recoverer = new DeferredUpdateSyncRecoverer<Counter>(instance);
            this.recoveryPointFactory = CopyCommitRecoveryPoint.Factory;

            this.instance = instance;
            this.initialVersion = ((IVersioned)instance).Version;
        }

        public int Value
        {
            get { return this.instance.Value; }
        }

        public void BeginChanges()
        {
            var rp = this.recoveryPointFactory.Prepare(this.instance);
            this.recoveryPoint = rp;
            this.instance = this.recoverer.Prepare(rp);
        }

        public void CommitChanges()
        {
            if (OriginalModified())
            {
                this.instance = this.recoveryPoint.Undo(this.instance);
                throw new Exception("Concurrency conflict. Object has been modified concurrently.");
            }

            this.recoverer.Redo(this.recoveryPoint);
        }

        public void Increase()
        {
            this.instance.Increase();
        }

        public void Reset()
        {
            this.instance.Reset();
        }

        public void Set(int value)
        {
            this.instance.Set(value);
        }

        private bool OriginalModified()
        {
            // TODO
            return false;

            var currentVersion = (this.instance as IVersioned).Version;

            //var currentVersion = (this.recoverer as DeferredUpdateSyncRecoverer<Counter>).CurrentVersion;
            //return this.Instance.Version.Equals(currentVersion);
        }
    }
}