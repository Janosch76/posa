namespace Js.Posa.CustomizableObjectRecovery.Sample.Model
{
    using System;

    public interface IVersioned
    {
        Guid Version { get; }

        void NewVersion();
    }
}
