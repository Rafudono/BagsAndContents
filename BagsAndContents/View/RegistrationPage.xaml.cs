using BagsAndContents.Model;

namespace BagsAndContents;

public partial class RegistrationPage : ContentPage
{
    public Bag SelectedBag { get; set; }
    public List<Bag> ListBags { get; set; } = new List<Bag>();
    public RegistrationPage()
	{
		InitializeComponent();
	}
    public async void UpdateCollections()
    {
        ListBags = await DataBase.GetInstance().GetBags();
        OnPropertyChanged(nameof(ListBags));
    }
    protected override void OnAppearing()
    {
        UpdateCollections();
    }
    private void Reload(object sender, EventArgs e)
    {
        UpdateCollections();
    }

}