namespace BagsAndContents
{
    public partial class MainPage : ContentPage
    {
        public Bag SelectedBag { get; set; }
        public List<Bag> ListBags { get; set; } = new List<Bag>();
        public MainPage()
        {
            InitializeComponent();
            //Здесь мы хотим при открытии увидеть сумки и подробности о них (с содержимым) в формате ListView (то есть можно выбрать 1 эл-т)
            //наверху мы хотим меню кнопочки для добавления редактирования и удаления контента или сумки
            //двойное нажатие=открыть сумку
            UpdateCollections();
            BindingContext = this;
        }
        public async void UpdateCollections()
        {
            ListBags = await DataBase.GetInstance().GetBags();
            OnPropertyChanged(nameof(ListBags));
        }
        private async void ImAdmin(object sender, EventArgs e)
        {
            AdminPage adm = new();
            await Navigation.PushAsync(adm);
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

}
