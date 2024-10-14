using System.Runtime.Intrinsics.Arm;

namespace BagsAndContents;

public partial class AdminPage : ContentPage
{
    public Bag SelectedBag { get; set; }= new Bag();
    public List<Bag> ListBags { get; set; } = new List<Bag>();
    public AdminPage()
	{
		InitializeComponent();

        UpdateCollections();

        BindingContext = this;
	}
    public async void UpdateCollections()
    {
        ListBags = await DataBase.GetInstance().GetBags();
        OnPropertyChanged(nameof(ListBags));
    }
    
    private async void AddorEditBag()
    {

        ShellNavigationQueryParameters bag = new (){
            { "id", SelectedBag.Id},
            {"owner", SelectedBag.OwnerName },
            {"type", SelectedBag.Type },
            {"contents", SelectedBag.BagContents }
        };
        await Shell.Current.GoToAsync("NewOrEditBagNavPage", bag);
        
    }
    protected override void OnAppearing()
    {
        UpdateCollections();
    }
    private async void DeleteBag(object sender, EventArgs e)
    {
        if (SelectedBag != null)
        {
            bool answer = await DisplayAlert("Удаление сумки", "Вы действительно хотите удалить сумку?", "да", "нет");
            if (answer == true)
            {
                DataBase.GetInstance().RemoveBag(SelectedBag.Id);
                UpdateCollections();
            }
        }
    }
    private void Reload(object sender, EventArgs e)
    {
        UpdateCollections();
    }

    private void AddBag(object sender, EventArgs e)
    {
        SelectedBag = new Bag();
        AddorEditBag();
    }
}