namespace Js.Posa.MVC.Sample.Controllers.Info1
{
    using Js.Posa.MVC.Sample.Model;

    /// <summary>
    /// Controller for a readonly view
    /// </summary>
    public class Info1Controller
    {
        private readonly Counter model;
        private readonly IView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="Info1Controller"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="view">The view.</param>
        public Info1Controller(Counter model, IView view)
        {
            this.model = model;
            this.view = view;

            WireEvents();
            UpdateView();
        }

        private void WireEvents()
        {
            this.model.PropertyChanged += (s, e) => UpdateView();
        }

        private void UpdateView()
        {
            this.view.Value = this.model.Value;
        }
    }
}
