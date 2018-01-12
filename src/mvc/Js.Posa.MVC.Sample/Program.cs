namespace Js.Posa.MVC.Sample
{
    using System;
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Admin;
    using Js.Posa.MVC.Sample.Controllers.Info1;
    using Js.Posa.MVC.Sample.Controllers.Info2;
    using Js.Posa.MVC.Sample.Model;
    using Js.Posa.MVC.Sample.Views.Admin;
    using Js.Posa.MVC.Sample.Views.Info1;
    using Js.Posa.MVC.Sample.Views.Info2;

    /// <summary>
    /// A sample MVC application with multiple views on the same model instance
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var counter = new Counter();
            var adminView = new AdminView();
            var adminController = new AdminController(counter, adminView);

            var view1 = new Info1View();
            var controller1 = new Info1Controller(counter, view1);
            view1.Show(adminView);

            var view2 = new Info2View();
            var controller2 = new Info2Controller(counter, view2);
            view2.Show(adminView);

            Application.Run(adminView);
        }
    }
}
