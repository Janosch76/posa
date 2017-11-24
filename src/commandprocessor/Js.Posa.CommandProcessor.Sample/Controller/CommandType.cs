namespace Js.Posa.CommandProcessor.Sample.Controller
{
    /// <summary>
    /// The command types
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// A command that requires no undo.
        /// </summary>
        NoChange,

        /// <summary>
        /// A command that can be undone.
        /// </summary>
        Undoable,

        /// <summary>
        /// A command that does not support undo.
        /// </summary>
        Normal
    }
}
