namespace Js.Posa.MVC.Sample.Controllers.Info2
{
    using Model;

    public class Info2Controller
    {
        private readonly Counter model;
        private readonly IView view;

        public Info2Controller(Counter model, IView view)
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
