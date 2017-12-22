namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;

    /// <summary>
    /// Signature for versioned objects.
    /// </summary>
    public interface IVersioned
    {
        /// <summary>
        /// Gets the version of an object.
        /// </summary>
        Guid Version { get; }
    }
}
