namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    /// <summary>
    /// Recovery point signature. Holds the object-specific part of an
    /// algorithm for object recovery.
    /// </summary>
    /// <typeparam name="T">The type of recoverable object.</typeparam>
    public abstract class RecoveryPoint<T>
    {
        public abstract T Prepare(T current);

        public abstract T Undo(T current);

        public abstract T Redo(T current);

        public interface Factory
        {
            RecoveryPoint<T> Prepare(T obj);
        }
    }
}