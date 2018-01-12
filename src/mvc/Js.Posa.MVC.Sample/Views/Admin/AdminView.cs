namespace Js.Posa.MVC.Sample.Views.Admin
{
    using System;
    using System.Windows.Forms;
    using Js.Posa.MVC.Sample.Controllers.Admin;

    /// <summary>
    /// The Admin view
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="Js.Posa.MVC.Sample.Controllers.Admin.IView" />
    public partial class AdminView : Form, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminView"/> class.
        /// </summary>
        public AdminView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when Increase of the counter value is requested in the view.
        /// </summary>
        public event EventHandler IncreaseRequested;

        /// <summary>
        /// Occurs when Reset of the counter is requested in the view.
        /// </summary>
        public event EventHandler ResetRequested;

        /// <summary>
        /// Sets the value.
        /// </summary>
        public int Value
        {
            set { this.textBox1.Text = value.ToString(); }
        }

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
