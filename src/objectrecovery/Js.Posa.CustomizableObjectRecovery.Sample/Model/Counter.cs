namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;

    /// <summary>
    /// A counter.
    /// </summary>
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Model.Observable" />
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="Js.Posa.CustomizableObjectRecovery.Sample.Model.IVersioned" />
    public class Counter : Observable, ICloneable, IVersioned
    {
        private Guid version;
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter"/> class.
        /// </summary>
        public Counter()
            : this(0, Guid.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter"/> class.
        /// </summary>
        /// <param name="counter">The counter.</param>
        public Counter(Counter counter)
            : this(counter.value, counter.version)
        {
        }

        private Counter(int value, Guid version)
        {
            this.value = value;
            this.version = version;
        }

        /// <summary>
        /// Gets the counter value.
        /// </summary>
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

        /// <summary>
        /// Increases the counter value.
        /// </summary>
        public void Increase()
        {
            Value++;
        }

        /// <summary>
        /// Sets the counter to the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Set(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Resets the counter value.
        /// </summary>
        public void Reset()
        {
            Value = 0;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A clone of the counter instance.</returns>
        public Counter Clone()
        {
            return new Counter(this);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Called when a property is changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
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
