﻿namespace Js.Posa.MVC.Sample.Controllers.Info1
{
    /// <summary>
    /// Signature of a readonly view
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Sets the value for display.
        /// </summary>
        int Value { set; }
    }
}