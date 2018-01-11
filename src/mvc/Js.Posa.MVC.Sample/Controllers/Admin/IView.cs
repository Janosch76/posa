namespace Js.Posa.MVC.Sample.Controllers.Admin
{
    using System;

    public interface IView
    {
        event EventHandler IncreaseRequested;
        event EventHandler ResetRequested;
    
        int Value { set; }
    }
}