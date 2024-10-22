namespace BagsAndContents;

public partial class RegistrationPage : ContentPage
{
    public string NickName { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public RegistrationPage()
	{
		InitializeComponent();
	}
}