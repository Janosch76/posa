namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;
    using Js.Posa.CustomizableObjectRecovery.Sample.Model;

    public class CopyCommitRecoveryPoint : RecoveryPoint<Counter>
    {
        private Counter original;

        public override Counter Prepare(Counter current)
        {
            this.original = current;
            return this.original.Clone();
        }

        public override Counter Redo(Counter current)
        {
            this.original.Set(current.Value);
            return this.original.Clone(); 
        }

        public override Counter Undo(Counter current)
        {
            return this.original.Clone();
        }

        new public static Factory Factory
        {
            get { return new CopyCommitRecoveryPointFactory(); }
        }

        private class CopyCommitRecoveryPointFactory : Factory
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
