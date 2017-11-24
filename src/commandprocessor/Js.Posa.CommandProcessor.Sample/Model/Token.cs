namespace Js.Posa.CommandProcessor.Sample.Model
{
    using System;

    /// <summary>
    /// Represents a token on the calculator evaluation stack.
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// A PLUS token
        /// </summary>
        public sealed class Plus : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "+";
            }
        }

        /// <summary>
        /// A MINUS token.
        /// </summary>
        public sealed class Minus : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "-";
            }
        }

        /// <summary>
        /// A TIMES token.
        /// </summary>
        public sealed class Times : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "*";
            }
        }

        /// <summary>
        /// A DIV token
        /// </summary>
        public sealed class Div : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "/";
            }
        }

        /// <summary>
        /// A RECIPROCAL token.
        /// </summary>
        public sealed class Recip : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "^-1";
            }
        }

        /// <summary>
        /// A LPAR token.
        /// </summary>
        public sealed class LPar : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "(";
            }
        }

        /// <summary>
        /// A RPAR token.
        /// </summary>
        public sealed class RPar : Token
        {
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return ")";
            }
        }

        /// <summary>
        /// A CONST token.
        /// </summary>
        public sealed class Const : Token
        {
            private readonly decimal value;

            /// <summary>
            /// Initializes a new instance of the <see cref="Const"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            public Const(decimal value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the decimal value.
            /// </summary>
            public decimal Value
            {
                get { return this.value; }
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return this.value.ToString();
            }
        }
    }
}
