using BagsAndContents.Model;

namespace BagsAndContents;

public partial class PersonalBag : ContentPage
{
	public PersonalBag()
	{
		InitializeComponent();
        BindingContext = this;
    }
    
}