namespace Js.Posa.MVC.Sample.Views.Info2
{
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Info2;

    public partial class Info2 : Form, IView
    {
        public Info2()
        {
            InitializeComponent();
        }

        public int Value
        {
            set { this.textBox1.Text = value.ToString(); }
        }
    }
}
