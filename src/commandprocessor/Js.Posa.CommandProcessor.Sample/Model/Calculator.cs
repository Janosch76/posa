namespace Js.Posa.CommandProcessor.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A simple calculator
    /// </summary>
    public class Calculator : IMemorable<Calculator>
    {
        private readonly List<Token> tokens;
        private decimal current;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        public Calculator()
        {
            this.current = 0;
            this.tokens = new List<Token>();
        }

        /// <summary>
        /// Gets the calculation result.
        /// </summary>
        public decimal Result
        {
            get { return this.current; }
        }

        /// <summary>
        /// Gets a string representation of the current stack.
        /// </summary>
        public string State
        {
            get { return string.Join(string.Empty, this.tokens.Select(t => t.ToString())); }
        }

        /// <summary>
        /// Enters a value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void EnterValue(decimal value)
        {
            Token topmost = this.tokens.LastOrDefault();
            if (topmost != null && topmost is Token.Const)
            {
                this.tokens.Clear();
            }

            this.tokens.Add(new Token.Const(value));
        }

        /// <summary>
        /// Evaluates the current expression.
        /// </summary>
        /// <returns>The evaluation result.</returns>
        public decimal Eval()
        {
            this.current = Evaluator.Evaluate(this.tokens.ToArray());
            return this.current;
        }

        /// <summary>
        /// Adds a plus token to the current calculator state.
        /// </summary>
        public void Plus()
        {
            this.tokens.Add(new Token.Plus());
        }

        /// <summary>
        /// Adds a minus token to the current calculator state.
        /// </summary>
        public void Minus()
        {
            this.tokens.Add(new Token.Minus());
        }

        /// <summary>
        /// Adds a times token to the current calculator state.
        /// </summary>
        public void Times()
        {
            this.tokens.Add(new Token.Times());
        }

        /// <summary>
        /// Adds a division token to the current calculator state.
        /// </summary>
        public void Div()
        {
            this.tokens.Add(new Token.Minus());
        }

        /// <summary>
        /// Adds a division token to the current calculator state.
        /// </summary>
        public void Reciprocal()
        {
            this.tokens.Add(new Token.Recip());
        }

        /// <summary>
        /// Adds a opening parenthesis to the current calculator state.
        /// </summary>
        public void OpenParenthesis()
        {
            this.tokens.Add(new Token.LPar());
        }

        /// <summary>
        /// Adds a closing parenthesis to the current calculator state.
        /// </summary>
        public void CloseParenthesis()
        {
            this.tokens.Add(new Token.RPar());
        }

        /// <summary>
        /// Resets the calculator state.
        /// </summary>
        public void Clear()
        {
            this.current = 0;
            this.tokens.Clear();
        }

        /// <summary>
        /// Creates a snapshot of the current calculator state.
        /// </summary>
        /// <returns>The snapshot of the current calculator state.</returns>
        public IMemento<Calculator> CreateMemento()
        {
            return new CalculatorMemento(this.current, this.tokens);
        }

        private class CalculatorMemento : IMemento<Calculator>
        {
            private readonly decimal current;
            private readonly IEnumerable<Token> tokens;

            public CalculatorMemento(decimal current, IEnumerable<Token> tokens)
            {
                this.current = current;
                this.tokens = tokens;
            }

            public void Set(Calculator instance)
            {
                instance.current = this.current;
                instance.tokens.Clear();
                instance.tokens.AddRange(this.tokens);
            }
        }
    }
}
