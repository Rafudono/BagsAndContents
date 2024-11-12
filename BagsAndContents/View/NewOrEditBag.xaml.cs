

using BagsAndContents.Model;
using BagsAndContents.ModelsForApi;

namespace BagsAndContents;

public partial class NewOrEditBag : ContentPage, IQueryAttributable
{
    public ModelsForApi.Bag NorEBag { get; set; } = new ModelsForApi.Bag();
    public ModelsForApi.Content SelectedContent { get; set; }
    public List<ModelsForApi.Content> Contents { get; set; } = new List<ModelsForApi.Content>();

	public NewOrEditBag()
	{
		InitializeComponent();
        DataBase.GetInstance();
        Contents = NorEBag.Contents.ToList();
		BindingContext = this;
	}
    public async void UpdateCollections()
    {
        OnPropertyChanged(nameof(NorEBag));
        Contents = new List<ModelsForApi.Content>();
        OnPropertyChanged(nameof(Contents));
        Contents = NorEBag.Contents.ToList();
        OnPropertyChanged(nameof(Contents));
    }
    private async void NewContent(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("NewContentNavPage");
        UpdateCollections();
    }

    private async void DelContent(object sender, EventArgs e)
    {
       var answer= await DisplayAlert("Удаление содержимого", $"Вы точно хотите выкинуть {SelectedContent.Name} из сумки?", "В мусорку!", "Попридержу пока..");
        if (answer)
        {
           await DataBase.GetInstance().RemoveContent(SelectedContent.Id);
            //DataBase.GetInstance().ReloadBagContent();
        }
        UpdateCollections();
    }
    protected override void OnAppearing()
    {
        UpdateCollections();
    }
    private async void Confirm (object sender, EventArgs e)
    {
        if (NorEBag != null)
        {
            if(NorEBag.Id== 0)
                HostApi.GetInstance().AddBag(NorEBag);
            else
            {
                // data.GetBagById(NorEBag.Id);
                HostApi.GetInstance().EditBag(NorEBag);
                
            }
            Shell.Current.GoToAsync("..");
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        NorEBag = (ModelsForApi.Bag)query["bag"];
    }     
}         