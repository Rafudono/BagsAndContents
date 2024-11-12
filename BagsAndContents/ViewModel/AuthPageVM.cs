using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class AuthPageVM:BaseVM
    {
        private string nickName;
        private string password;

        public string NickName { get => nickName; set
            {
                nickName = value;
                Signal();
            }
        }
        public string Password { get => password; set
            {
                password = value;
                Signal();
            }
        }
        public VmCommand LogIntoAc { get; }
        public AuthPageVM()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            LogIntoAc = new VmCommand(async () =>
            {
                Signal(nameof(NickName));
                Signal(nameof(Password));
                if (NickName == null || Password == null)
                { await Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля!", "ок"); return; }
                else
                {
                    SearchUserByLoginAndPassword searchdata = new SearchUserByLoginAndPassword() { Login = NickName, Password=Password };
                    var user = await HostApi.GetInstance().IsUserRegistred(searchdata);
                    if (user.Id != 0)
                    {
                        AuthorizedUser.GetInstance().AuthorizedPerson = user;
                        AuthorizedUser.GetInstance().CheckIsAdmin();
                        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                        await Shell.Current.GoToAsync("//Overview");
                    }
                    else
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Такого аккаунта не существует", "ок");
                    return;
                }
            });
            }

        internal void OnAppearing()
        {
            NickName = "";
            Password = "";
        }
    }
}
