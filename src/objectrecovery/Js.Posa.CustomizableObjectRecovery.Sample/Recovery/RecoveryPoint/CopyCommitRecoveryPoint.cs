namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;

    /// <summary>
    /// A copying recovery point.
    /// </summary>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint.RecoveryPoint{Js.Posa.CustomizableObjectRecovery.Sample.Model.Counter}" />
    public class CopyCommitRecoveryPoint : RecoveryPoint<Counter>
    {
        private Counter original;

        /// <summary>
        /// Gets a factory for <see cref="CopyCommitRecoveryPoint"/> objects.
        /// </summary>
        public static IFactory Factory
        {
            get { return new CopyCommitRecoveryPointFactory(); }
        }

        /// <summary>
        /// Initializes the recovery point from the given current object.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// Returns the working instance, typically the given
        /// current object or a working copy.
        /// </returns>
        public override Counter Prepare(Counter current)
        {
            this.original = current;
            return this.original.Clone();
        }

        /// <summary>
        /// Redo changes from the given current  instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// The updated working instance.
        /// </returns>
        public override Counter Redo(Counter current)
        {
            this.original.Set(current.Value);
            return this.original.Clone(); 
        }

        /// <summary>
        /// Undo changes in the given current  instance.
        /// </summary>
        /// <param name="current">The current instance.</param>
        /// <returns>
        /// The updated working instance.
        /// </returns>
        public override Counter Undo(Counter current)
        {
            return this.original.Clone();
        }

        private class CopyCommitRecoveryPointFactory : IFactory
        {
            public RecoveryPoint<Counter> Prepare(Counter obj)
            {
                var rp = new CopyCommitRecoveryPoint();
                rp.Prepare(obj);
                return rp;
            }
        }
    }
}
