using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class PersonalBagVM : BaseVM
    {
        private Bag myBag = new();
        private Content selectedContent;

        public Bag MyBag { get => myBag; set
            {
                myBag = value;
                Signal();
            }
        }
        public Content SelectedContent { get => selectedContent; set
            {
                selectedContent = value;
                Signal();
            }
        }
        //здесь редактор для сумки авторизированного пользователя
        public VmCommand NewContent { get; }
        public VmCommand DelContent { get; }
        public VmCommand Confirm { get; }
        public PersonalBagVM()
        {
            Signal(nameof(MyBag));

            NewContent = new VmCommand(async () =>
            {
                await Shell.Current.GoToAsync("NewContentNavPage");
            });
            DelContent = new VmCommand(async () =>
            {
                if (SelectedContent != null)
                {
                    bool answ = await Application.Current.MainPage.DisplayAlert("Удаление содержимого", $"Вы точно хотите выкинуть {SelectedContent.Name} из сумки?", "В мусорку!", "Попридержу пока..");
                    if (answ == true)
                    {
                        await HostApi.GetInstance().RemoveContent(SelectedContent);
                        IniMyBag();
                    }
                }
            });
            Confirm = new VmCommand(async () =>
            {
                if (MyBag.Id == 0)
                {
                    MyBag.OwnerId = AuthorizedUser.GetInstance().AuthorizedPerson.Id;
                    MyBag.Owner = AuthorizedUser.GetInstance().AuthorizedPerson;
                }
                await HostApi.GetInstance().EditBag(MyBag);
                //щас бы уведы сделать для юзера
                await Shell.Current.GoToAsync("//Overview");
            });
        }
        public async void IniMyBag()
        {
            var bag = await HostApi.GetInstance().GetMyBag(AuthorizedUser.GetInstance().AuthorizedPerson);
            MyBag = bag;
            Signal(nameof(MyBag));
        }

        internal void OnAppearing()
        {
            IniMyBag();
        }
    }
}
