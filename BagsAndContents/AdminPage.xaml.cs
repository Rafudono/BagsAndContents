using System.Runtime.Intrinsics.Arm;

namespace BagsAndContents;

public partial class AdminPage : ContentPage
{
    DataBase db = new DataBase();
    public Bag SelectedBag { get; set; }
    public List<Bag> ListBags { get; set; } = new List<Bag>();
    public AdminPage()
	{
		InitializeComponent();

        ListBags = db.Bags;

        BindingContext = this;
	}


    private async void AddorEditBag(object sender, EventArgs e)
    {
        if (SelectedBag != null)
        {
            NewOrEditBag nb = new(SelectedBag.Id);
            await Navigation.PushAsync(nb);
        }
        else
        {
            NewOrEditBag nb = new(0);
            await Navigation.PushAsync(nb);
        }
    }

    private async void DeleteBag(object sender, EventArgs e)
    {
        if (SelectedBag != null)
        {
            bool answer = await DisplayAlert("Удаление сумки", "Вы действительно хотите удалить сумку?", "да", "нет");
            if (answer == true)
            {
                db.Bags.Remove(SelectedBag);
                ListBags=db.Bags;
            }
        }
    }
}