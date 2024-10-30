using BagsAndContents.Model;
using BagsAndContents.ViewModel;

namespace BagsAndContents;

public partial class AuthorizationPage : ContentPage
{

	public AuthorizationPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        ((AuthPageVM)BindingContext).OnAppearing();
        base.OnAppearing();
    }
}