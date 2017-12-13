namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    /// <summary>
    /// Recovery point signature
    /// </summary>
    /// <typeparam name="T">The type of recoverable object</typeparam>
    public abstract class RecoveryPoint<T>
    {
        public abstract T Value { get; }

        public abstract void Prepare(T current);

        public abstract T Undo(T current);

        public abstract T Redo(T current);

        public interface Factory
        {
            RecoveryPoint<T> Prepare(T obj);
        }
    }
}