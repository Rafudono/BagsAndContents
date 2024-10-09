namespace BagsAndContents;

public partial class NewContent : ContentPage
{
	public Content NeWContent { get; set; } = new Content();
	public NewContent()
	{
		InitializeComponent();
		DataBase.GetInstance();
		BindingContext = this;
	}

	private void Save(object sender, EventArgs e)
	{

		if (NeWContent != null)
		{
            DataBase.GetInstance().AddContent(NeWContent);
			Navigation.PopAsync();
		}
	}
}