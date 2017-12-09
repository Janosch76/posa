namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint
{
    using System;

    /// <summary>
    /// Recovery point signature
    /// </summary>
    /// <typeparam name="T">The type of recoverable object</typeparam>
    public interface IRecoveryPoint<T>
    {
        T Prepare(T current);

        T Undo(T current);

        T Redo(T current);
    }
}