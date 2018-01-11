namespace Js.Posa.MVC.Sample.Views.Info1
{
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Info1;

    public partial class Info1 : Form, IView
    {
        public Info1()
        {
            InitializeComponent();
        }

        public int Value
        {
            set { this.textBox1.Text = value.ToString(); }
        }
    }
}
