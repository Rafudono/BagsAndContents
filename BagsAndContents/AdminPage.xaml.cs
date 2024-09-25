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


    private void AddNewBag(object sender, EventArgs e)
    {

    }

    private void EditSelBag(object sender, EventArgs e)
    {

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