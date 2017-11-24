namespace Js.Posa.CommandProcessor.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Evaluator for the calculator state
    /// </summary>
    public class Evaluator
    {
        private readonly Token[] tokens;
        private int position;

        private Evaluator(IEnumerable<Token> tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            this.tokens = tokens.DefaultIfEmpty(new Token.Const(0)).ToArray();
            this.position = 0;
        }

        /// <summary>
        /// Evaluates a given token stream.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns>The evaluation result</returns>
        public static decimal Evaluate(IEnumerable<Token> tokens)
        {
            var evaluator = new Evaluator(tokens);
            return evaluator.EvalExp();
        }

        private Token Peek()
        {
            return this.position < this.tokens.Length ? this.tokens[this.position] : null;
        }

        private decimal EvalExp()
        {
            return EvalExp1(EvalMExp());
        }

        private decimal EvalExp1(decimal accumulator)
        {
            var nextToken = Peek();
            if (nextToken is Token.Plus)
            {
                this.position++;
                return EvalExp1(accumulator + EvalMExp());
            }
            else if (nextToken is Token.Minus)
            {
                this.position++;
                return EvalExp1(accumulator - EvalMExp());
            }
            else
            {
                return accumulator;
            }
        }

        private decimal EvalMExp()
        {
            return EvalMExp1(EvalPExp());
        }

        private decimal EvalMExp1(decimal accumulator)
        {
            var nextToken = Peek();
            if (nextToken is Token.Times)
            {
                this.position++;
                return EvalMExp1(accumulator * EvalPExp());
            }
            else if (nextToken is Token.Div)
            {
                this.position++;
                return EvalMExp1(accumulator / EvalPExp());
            }
            else
            {
                return accumulator;
            }
        }

        private decimal EvalPExp()
        {
            var nextToken = Peek();
            if (nextToken is Token.Const)
            {
                this.position++;
                return ((Token.Const)nextToken).Value;
            }
            else if (nextToken is Token.LPar)
            {
                this.position++;
                var result = EvalExp();
                Match<Token.RPar>();
                return result;
            }

            throw new Exception($"Parse error: expected 'pexp'.");
        }

        private void Match<T>() where T : Token
        {
            var nextToken = Peek();
            if (!(nextToken is T))
            {
                throw new Exception($"Parse error: expected {typeof(T).Name} but found {nextToken}.");
            }

            this.position++;
        }
    }
}
