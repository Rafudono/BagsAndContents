using BagsAndContents.Model;
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
        public Bag MyBag { get; set; } = new();
        public Content SelectedContent { get; set; }
        //здесь редактор для сумки авторизированного пользователя
        public VmCommand NewContent { get; }
        public VmCommand DelContent { get; }
        public VmCommand Confirm { get; }
        public PersonalBagVM()
        {
            IniMyBag();
            Signal(nameof(MyBag));

            NewContent = new VmCommand(async () =>
            {
                await Shell.Current.GoToAsync("//NewContentNavPage");
            });
            DelContent = new VmCommand(async () =>
            {
                //щас бы алерт сюда...
            });
            Confirm = new VmCommand(async () =>
            {
                MyBag.OwnerId=AuthorizedUser.GetInstance().AuthorizedPerson.Id;
                MyBag.Owner=AuthorizedUser.GetInstance().AuthorizedPerson;
                await DataBase.GetInstance().EditBag(MyBag);
                //щас бы уведы сделать для юзера
                await Shell.Current.GoToAsync("//Overview");
            });
        }
        public async void IniMyBag()
        {
            var bag = await DataBase.GetInstance().GetMyBag();
            MyBag = bag;
        }
    }
}
