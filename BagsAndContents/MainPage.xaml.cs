namespace BagsAndContents
{
    public partial class MainPage : ContentPage
    {
        DataBase db = new DataBase();
        public Bag SelectedBag { get; set; }
        public List<Bag> ListBags { get; set; } = new List<Bag>();
        public MainPage()
        {
            InitializeComponent();
            //Здесь мы хотим при открытии увидеть сумки и подробности о них (с содержимым) в формате ListView (то есть можно выбрать 1 эл-т)
            //наверху мы хотим меню кнопочки для добавления редактирования и удаления контента или сумки
            //двойное нажатие=открыть сумку
            ListBags = db.Bags;
            BindingContext = this;
        }

        private async void ImAdmin(object sender, EventArgs e)
        {
            AdminPage adm = new();
            await Navigation.PushAsync(adm);
        }
    }

}
