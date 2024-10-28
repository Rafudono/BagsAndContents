using BagsAndContents.Model;

namespace BagsAndContents;

public partial class AuthorizationPage : ContentPage
{
	public string NickName { get; set; }
	public string Password { get; set; }

	public AuthorizationPage()
	{
		InitializeComponent();
	}

    private void GoRegistration(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("RegPage");
    }

  
    private async void LogIntoAc(object sender, EventArgs e)
    {

        OnPropertyChanged(nameof(NickName));
        OnPropertyChanged(nameof(Password));
        if (NickName == null || Password == null) { await DisplayAlert("Ошибка", "Заполните все поля!", "ок"); return; }
        else
        {
            //сменить страницу и войти
            var user =  DataBase.GetInstance().IsUserRegistred(NickName, Password).Result;
            if (user.Id != 0)
            {
                AuthorizedUser.GetInstance().AuthorizedPerson = user;
                AuthorizedUser.GetInstance().CheckIsAdmin();
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                await Shell.Current.GoToAsync("//Overview");
            }
            else
                await DisplayAlert("Ошибка", "Такого аккаунта не существует", "ок");
            return;
        }
    }
}