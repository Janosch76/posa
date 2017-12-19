namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Counter : ICloneable, IVersioned
    {
        private Guid version;
        private int value;

        public Counter()
            : this(0, Guid.Empty)
        {
        }

        public Counter(Counter counter)
            : this(counter.value, counter.version)
        {
        }

        private Counter(int value, Guid version)
        {
            this.value = value;
            this.version = version;
        }

        public int Value
        {
            get { return this.value; }
        }

        public Guid Version
        {
            get { return this.version; }
        }

        Guid IVersioned.Version
        {
            get { return this.version; }
        }

        public void Increase()
        {
            this.value++;
        }

        public void Reset()
        {
            this.value = 0;
        }

        public Counter Clone()
        {
            return new Counter(this);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        void IVersioned.NewVersion()
        {
            this.version = Guid.NewGuid();
        }
    }
}
