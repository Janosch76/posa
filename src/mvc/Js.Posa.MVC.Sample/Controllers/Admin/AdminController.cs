namespace Js.Posa.MVC.Sample.Controllers.Admin
{
    using Js.Posa.MVC.Sample.Model;

    /// <summary>
    /// Controller for the Admin view
    /// </summary>
    public class AdminController
    {
        private readonly Counter model;
        private readonly IView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="view">The view.</param>
        public AdminController(Counter model, IView view)
        {
            this.model = model;
            this.view = view;

            WireEvents();
            UpdateView();
        }

        private void WireEvents()
        {
            this.model.PropertyChanged += (s, e) => UpdateView();

            this.view.IncreaseRequested += (s, e) => this.model.Increase();
            this.view.ResetRequested += (s, e) => this.model.Reset();
        }

        private void UpdateView()
        {
            this.view.Value = this.model.Value;
        }
    }
}
