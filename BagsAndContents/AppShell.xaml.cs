namespace BagsAndContents
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddOrEditBag", typeof(NewOrEditBag));
        }
    }
}
