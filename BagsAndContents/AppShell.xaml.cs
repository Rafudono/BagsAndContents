using BagsAndContents.Model;

namespace BagsAndContents
{
    public partial class AppShell : Shell
    {
        public bool IsAdmin => AuthorizedUser.IsAdmin;

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("NewOrEditBagNavPage", typeof(NewOrEditBag));
            Routing.RegisterRoute("NewContentNavPage", typeof(NewContent));
            
            BindingContext = this;
        }

        private async void LogOut(object sender, EventArgs e)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            AuthorizedUser.GetInstance().AuthorizedPerson = new Person();
            await Current.GoToAsync("//Auth");
        }
    }
}
