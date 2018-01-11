namespace Js.Posa.MVC.Sample.Controllers.Admin
{
    using Model;

    public class AdminController
    {
        private readonly Counter model;
        private readonly IView view;

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
