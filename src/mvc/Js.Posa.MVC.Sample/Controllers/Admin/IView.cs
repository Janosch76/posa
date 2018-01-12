namespace Js.Posa.MVC.Sample.Controllers.Admin
{
    using System;

    /// <summary>
    /// Signature of the Admin view
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Occurs when Increase of the counter value is requested in the view.
        /// </summary>
        event EventHandler IncreaseRequested;

        /// <summary>
        /// Occurs when Reset of the counter is requested in the view.
        /// </summary>
        event EventHandler ResetRequested;

        /// <summary>
        /// Sets the value.
        /// </summary>
        int Value { set; }
    }
}