namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;
    using System.ComponentModel;

    public class Counter : Observable, ICloneable, IVersioned
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
            get
            {
                return this.value;
            }

            private set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        Guid IVersioned.Version
        {
            get { return this.version; }
        }

        public void Increase()
        {
            Value++;
        }

        public void Set(int value)
        {
            Value = value;
        }

        public void Reset()
        {
            Value = 0;
        }

        public Counter Clone()
        {
            return new Counter(this);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            SetNewInstanceVersion();
            base.OnPropertyChanged(propertyName);
        }

        private void SetNewInstanceVersion()
        {
            this.version = Guid.NewGuid();
        }
    }
}
