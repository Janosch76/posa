namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Counter : ICloneable
    {
        private int value;

        public Counter()
            : this(0)
        {
        }

        public Counter(Counter counter)
            : this(counter.value)
        {
        }

        private Counter(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return this.value; }
        }

        public void Increase()
        {
            this.value++;
        }

        public void Reset()
        {
            this.value = 0;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Counter Clone()
        {
            return new Counter(this);
        }
    }
}
