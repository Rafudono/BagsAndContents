using BagsAndContents.Model;
using BagsAndContents.ViewModel;

namespace BagsAndContents;

public partial class PersonalBag : ContentPage
{
	public PersonalBag()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        ((PersonalBagVM)BindingContext).OnAppearing();
        base.OnAppearing();
    }
}