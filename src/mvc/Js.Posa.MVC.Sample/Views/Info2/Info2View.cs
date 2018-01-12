namespace Js.Posa.MVC.Sample.Views.Info2
{
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Info2;

    /// <summary>
    /// A readonly view
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="Js.Posa.MVC.Sample.Controllers.Info2.IView" />
    public partial class Info2View : Form, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info2View"/> class.
        /// </summary>
        public Info2View()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the value for display.
        /// </summary>
        public int Value
        {
            set { this.textBox1.Text = value.ToString(); }
        }
    }
}
