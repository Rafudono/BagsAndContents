using BagsAndContents.Model;
using BagsAndContents.ViewModel;

namespace BagsAndContents
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ((MainPageVM)BindingContext).OnAppearing();
            base.OnAppearing();
        }
    }

}
