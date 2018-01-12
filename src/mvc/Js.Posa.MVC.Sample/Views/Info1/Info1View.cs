namespace Js.Posa.MVC.Sample.Views.Info1
{
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Info1;

    /// <summary>
    /// A readonly view
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="Js.Posa.MVC.Sample.Controllers.Info1.IView" />
    public partial class Info1View : Form, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info1View"/> class.
        /// </summary>
        public Info1View()
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
