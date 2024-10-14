namespace BagsAndContents
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("NewOrEditBagNavPage", typeof(NewOrEditBag));
            Routing.RegisterRoute("NewContentNavPage", typeof(NewContent));

        }
    }
}
