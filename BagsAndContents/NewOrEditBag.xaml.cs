namespace BagsAndContents;

public partial class NewOrEditBag : ContentPage
{
	DataBase data;
	public Bag NorEBag { get; set; }=new Bag();
	public NewOrEditBag(Bag selBag)
	{
		InitializeComponent();
		data = new DataBase();
        NorEBag = selBag; 
		BindingContext = this;
	}

    private void NewContent(object sender, EventArgs e)
    {

    }

    private void DelContent(object sender, EventArgs e)
    {

    }

    private async void Confirm (object sender, EventArgs e)
    {
        if (NorEBag != null)
        {
            if(NorEBag.Id== 0) 
            data.AddBag(NorEBag);
            else
            {
               // data.GetBagById(NorEBag.Id);
                data.RemoveBag(data.GetBagById(NorEBag.Id));
            }
        }
    }
}