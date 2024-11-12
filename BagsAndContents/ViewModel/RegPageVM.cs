using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class RegPageVM: BaseVM
    {
        public string NickName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public VmCommand CreateAc { get; }
        public RegPageVM() {
            CreateAc = new VmCommand(async () =>
            {
                Signal(nameof(NickName));
                Signal(nameof(Password));
                Signal(nameof(UserName));
                if (NickName == null || Password == null || UserName == null)
                { //await DisplayAlert("Ошибка", "Заполните все поля!", "ок");
                    return;
                }
                else
                {
                    //сменить страницу и войти
                    SearchUserByLoginAndPassword searchdata = new SearchUserByLoginAndPassword() { Login = NickName, Password = Password };
                    var user = await HostApi.GetInstance().IsUserRegistred(searchdata);
                    if (user.Id != 0)
                    {
                        // await DisplayAlert(" ", "Такой уже есть, войдите в аккаунт", "ок");
                    }
                    else
                    {
                        User user1 = new () { Login = NickName, Password = Password, Name = UserName };
                        await HostApi.GetInstance().AddUser(user1);
                        await Application.Current.MainPage.DisplayAlert("Системное уведомление", "Регистрация прошла успешно!", "ок");
                        AuthorizedUser.GetInstance().AuthorizedPerson = user;
                        AuthorizedUser.GetInstance().CheckIsAdmin();
                        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                        await Shell.Current.GoToAsync("//Overview");
                    }
                    return;
                }
            });
        }
        //в команду
        /*OnPropertyChanged(nameof(NickName));
        OnPropertyChanged(nameof(Password));
        if (NickName == null || Password == null) { await DisplayAlert("Ошибка", "Заполните все поля!", "ок"); return; }
        else
        {
            //сменить страницу и войти
            var user = DataBase.GetInstance().IsUserRegistred(NickName, Password).Result;
            if (user.Id != 0)
            {
                await DisplayAlert(" ", "Такой уже есть, войдите в аккаунт", "ок");
            }
            else
            {
                var person = new Person { Login = NickName, Password = Password, Name = UserName };
                DataBase.GetInstance().AddUser(person);
                await DisplayAlert(" ", "Регистрация прошла успешно!", "ок");
                AuthorizedUser.GetInstance().AuthorizedPerson = person;
                AuthorizedUser.GetInstance().CheckIsAdmin();
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                await Shell.Current.GoToAsync("//Overview");
            }
            return;
        }*/

    }
}
