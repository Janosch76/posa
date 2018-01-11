using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Js.Posa.MVC.Sample.Model
{
    public class Counter : Observable
    {
        private int value;

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

        public void Increase()
        {
            Value += 1;        
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}
