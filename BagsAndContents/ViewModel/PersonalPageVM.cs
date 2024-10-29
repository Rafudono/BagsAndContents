using BagsAndContents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class PersonalPageVM:BaseVM
    {
        public Person Person { get; set; }
        public VmCommand Save {  get; }
        public PersonalPageVM()
        {
            Person = AuthorizedUser.GetInstance().AuthorizedPerson;
            Save = new VmCommand(async () =>
            {
                if (Person != AuthorizedUser.GetInstance().AuthorizedPerson)
                {
                    await DataBase.GetInstance().EditUser(Person);
                    await Shell.Current.GoToAsync("//Overview");
                }
            });
        }

    }
}
