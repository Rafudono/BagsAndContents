using BagsAndContents.Model;

namespace BagsAndContents;

public partial class PersonalBag : ContentPage
{
    public Bag MyBag { get; set; }
	//здесь редактор для сумки авторизированного пользователя
	public PersonalBag()
	{
		InitializeComponent();
        BindingContext = this;
    }
    public async void UpdateCollections()
    {
        MyBag = DataBase.GetInstance().GetBags().Result.Where(s => s.OwnerId == AuthorizedUser.GetInstance().AuthorizedPerson.Id).FirstOrDefault();
        OnPropertyChanged(nameof(MyBag));
    }


    protected override void OnAppearing()
    {
        UpdateCollections();
    }
    private void NewContent(object sender, EventArgs e)
    {

    }

    private void DelContent(object sender, EventArgs e)
    {

    }

    private void Confirm(object sender, EventArgs e)
    {

    }
}