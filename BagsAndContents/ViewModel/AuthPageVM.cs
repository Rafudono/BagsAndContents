using BagsAndContents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class AuthPageVM:BaseVM
    {

        public string NickName { get; set; }
        public string Password { get; set; }
        public VmCommand LogIntoAc { get; }
        public AuthPageVM()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            LogIntoAc = new VmCommand(async () =>
            {
                Signal(nameof(NickName));
                Signal(nameof(Password));
                if (NickName == null || Password == null) { }
                // { await DisplayAlert("Ошибка", "Заполните все поля!", "ок"); return; }
                else
                {
                    //сменить страницу и войти
                    var user = await DataBase.GetInstance().IsUserRegistred(NickName, Password);
                    if (user.Id != 0)
                    {
                        AuthorizedUser.GetInstance().AuthorizedPerson = user;
                        AuthorizedUser.GetInstance().CheckIsAdmin();
                        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                        await Shell.Current.GoToAsync("//Overview");
                    }
                    else { }
                    // await DisplayAlert("Ошибка", "Такого аккаунта не существует", "ок");
                    return;
                }
            });
            }



    }
}
