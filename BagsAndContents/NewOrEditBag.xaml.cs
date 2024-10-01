namespace BagsAndContents;

public partial class NewOrEditBag : ContentPage
{
	public Bag NorEBag { get; set; }=new Bag();
    public List<Content> Contents { get; set; } = new List<Content>();
	public NewOrEditBag(Bag selBag)
	{
		InitializeComponent();
        DataBase.GetInstance();
        NorEBag = selBag; 
		BindingContext = this;
	}
    public async void UpdateCollections()
    {
        Contents = await DataBase.GetInstance().GetContents();
    }
    private async void NewContent(object sender, EventArgs e)
    {
        NewContent nContent = new();
        await Navigation.PushAsync(nContent);
    }

    private void DelContent(object sender, EventArgs e)
    {

    }

    private async void Confirm (object sender, EventArgs e)
    {
        if (NorEBag != null)
        {
            if(NorEBag.Id== 0)
                DataBase.GetInstance().AddBag(NorEBag);
            else
            {
                // data.GetBagById(NorEBag.Id);
                DataBase.GetInstance().EditBag(NorEBag);
            }
        }
    }
}