namespace Js.Posa.CommandProcessor.Sample.Model
{
    /// <summary>
    /// Signature of a <typeparamref name="T"/> state snapshot that can be re-instated
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    public interface IMemento<T>
    {
        /// <summary>
        /// Sets the snapshot state on a specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        void Set(T instance);
    }
}