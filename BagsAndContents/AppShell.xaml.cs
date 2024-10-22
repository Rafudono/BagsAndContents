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
            Routing.RegisterRoute("AuthPage", typeof(NewContent));
            Routing.RegisterRoute("RegPage", typeof(NewContent));
            BindingContext = this;
        }
    }
}
