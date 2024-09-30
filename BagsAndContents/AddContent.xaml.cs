namespace BagsAndContents;

public partial class AddContent : ContentPage
{
	DataBase dataBase = new DataBase();
	public Content NewContent { get; set; } = new Content();
	public AddContent()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void AddNewContent(object sender, EventArgs e)
    {
		dataBase.AddContent(NewContent);
    }
}