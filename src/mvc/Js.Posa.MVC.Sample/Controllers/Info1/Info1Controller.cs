namespace Js.Posa.MVC.Sample.Controllers.Info1
{
    using Model;

    public class Info1Controller
    {
        private readonly Counter model;
        private readonly IView view;

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
