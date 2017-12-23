namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// A wrapper for <see cref="Counter"/> instances for an 
    /// optimistic concurrency synchronization strategy
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OptimisticSyncRecoverable : IDisposable
    {
        private readonly Counter original;
        private readonly Guid initialVersion;
        private readonly DeferredUpdateSyncRecoverer<Counter> recoverer;
        private readonly RecoveryPoint<Counter> recoveryPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticSyncRecoverable"/> class.
        /// </summary>
        /// <param name="instance">The counter instance.</param>
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

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value
        {
            get { return this.recoverer.WorkingCopy.Value; }
        }

        /// <summary>
        /// Increases the counter value.
        /// </summary>
        public void Increase()
        {
            this.recoverer.WorkingCopy.Increase();
        }

        /// <summary>
        /// Resets the counter value.
        /// </summary>
        public void Reset()
        {
            this.recoverer.WorkingCopy.Reset();
        }

        /// <summary>
        /// Sets the counter to a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Set(int value)
        {
            this.recoverer.WorkingCopy.Set(value);
        }

        /// <summary>
        /// Commits the changes done on the working copy to the underlying <see cref="Counter"/> instance.
        /// </summary>
        public void CommitChanges()
        {
            if (OriginalModified())
            {
                throw new Exception("Concurrency conflict. Object has been modified concurrently.");
            }

            this.recoverer.Redo(this.recoveryPoint);
        }

        /// <summary>
        /// no op; just to limit scope with using keyword
        /// </summary>
        public void Dispose()
        {
        }

        private bool OriginalModified()
        {
            var currentVersion = (this.original as IVersioned).Version;
            return !this.initialVersion.Equals(currentVersion);
        }
    }
}