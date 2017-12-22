namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    public class OptimisticSyncRecoverable : IDisposable
    {
        private readonly Counter original;
        private readonly Guid initialVersion;
        private readonly DeferredUpdateSyncRecoverer<Counter> recoverer;
        private readonly RecoveryPoint<Counter> recoveryPoint;

        public OptimisticSyncRecoverable(Counter instance) 
        {
            this.original = instance;
            this.initialVersion = ((IVersioned)instance).Version;

            var recoveryPointFactory = CopyCommitRecoveryPoint.Factory;
            var rp = recoveryPointFactory.Prepare(instance);
            this.recoveryPoint = rp;

            this.recoverer = new DeferredUpdateSyncRecoverer<Counter>(instance);
            this.recoverer.Prepare(rp);
        }

        public int Value
        {
            get { return this.recoverer.WorkingCopy.Value; }
        }

        public void Increase()
        {
            this.recoverer.WorkingCopy.Increase();
        }

        public void Reset()
        {
            this.recoverer.WorkingCopy.Reset();
        }

        public void Set(int value)
        {
            this.recoverer.WorkingCopy.Set(value);
        }

        public void CommitChanges()
        {
            if (OriginalModified())
            {
                throw new Exception("Concurrency conflict. Object has been modified concurrently.");
            }

            this.recoverer.Redo(this.recoveryPoint);
        }

        public void Dispose()
        {
            // no op; just to limit scope with using keyword
        }

        private bool OriginalModified()
        {
            var currentVersion = (this.original as IVersioned).Version;
            return !this.initialVersion.Equals(currentVersion);
        }
    }
}