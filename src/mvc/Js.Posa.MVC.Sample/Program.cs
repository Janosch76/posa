namespace Js.Posa.MVC.Sample
{
    using Controllers.Admin;
    using Controllers.Info1;
    using Controllers.Info2;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Views.Admin;
    using Views.Info1;
    using Views.Info2;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var counter = new Counter();
            var adminView = new AdminView();
            var adminController = new AdminController(counter, adminView);

            var view1 = new Info1();
            var controller1 = new Info1Controller(counter, view1);
            view1.Show(adminView);

            var view2 = new Info2();
            var controller2 = new Info2Controller(counter, view2);
            view2.Show(adminView);

            Application.Run(adminView);
        }
    }
}
