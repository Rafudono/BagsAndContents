namespace BagsAndContents;

public partial class AddContent : ContentPage
{

	public Content NewContent { get; set; } = new Content();
	public AddContent(int bagId)
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void AddNewContent(object sender, EventArgs e)
    {
		DataBase.GetInstance().AddContent(NewContent);
		Navigation.PopAsync();
    }
}