namespace Js.Posa.MVC.Sample.Model
{
    /// <summary>
    /// A simple counter with observable value
    /// </summary>
    /// <seealso cref="Js.Posa.MVC.Sample.Model.Observable" />
    public class Counter : Observable
    {
        private int value;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value != this.value)
                {
                    this.value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        /// <summary>
        /// Increases the counter value.
        /// </summary>
        public void Increase()
        {
            Value += 1;        
        }

        /// <summary>
        /// Resets the counter value to 0.
        /// </summary>
        public void Reset()
        {
            Value = 0;
        }
    }
}
