namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using Recovery.Recoverable;
    using Recovery.RecoveryPoint;
    using System;

    // recovery interface
    public class RecoverableCounter : Recoverable<Counter>
    {
        public RecoverableCounter(Counter obj) 
            : base(obj)
        {
        }

        public int Value
        {
            get { return this.recoverer.Current.Value; }
        }

        public void Increase()
        {
            RecoveryPoint<Counter> rp = this.recoverer.Prepare();
            this.recoverer.Current.Increase();
            this.pastRecoveryPoints.Push(rp);
            this.futureRecoveryPoints.Clear();
        }

        public void Reset()
        {
            RecoveryPoint<Counter> rp = this.recoverer.Prepare();
            this.recoverer.Current.Reset();
            this.pastRecoveryPoints.Push(rp);
            this.futureRecoveryPoints.Clear();
        }
    }
}
