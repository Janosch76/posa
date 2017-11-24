namespace Js.Posa.CommandProcessor.Sample.Model
{
    /// <summary>
    /// Signature for objects that can create snapshots of their internal state.
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    public interface IMemorable<T>
    {
        /// <summary>
        /// Creates the snapshot.
        /// </summary>
        /// <returns>A snapshot of the <paramref name="T"/> instance.</returns>
        IMemento<T> CreateMemento();
    }
}