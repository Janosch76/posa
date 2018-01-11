namespace Js.Posa.MVC.Sample.Views.Admin
{
    using System;
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Admin;

    public partial class AdminView : Form, IView
    {
        public AdminView()
        {
            InitializeComponent();
        }

        public int Value
        {
            set { this.textBox1.Text = value.ToString(); }
        }

        public event EventHandler IncreaseRequested;

        public event EventHandler ResetRequested;

        private void button1_Click(object sender, EventArgs e)
        {
            OnIncreaseRequested();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnResetRequested();
        }

        private void OnIncreaseRequested()
        {
            IncreaseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnResetRequested()
        {
            ResetRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
