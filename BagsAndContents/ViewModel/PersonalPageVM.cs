using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class PersonalPageVM:BaseVM
    {
        private User user;

        public User _User
        {
            get => user; set
            {
                user = value;
                Signal();
            }
        }
        public VmCommand Save {  get; }
        public PersonalPageVM()
        {
            _User = AuthorizedUser.GetInstance().AuthorizedPerson;
            Save = new VmCommand(async () =>
            {
                if (_User != AuthorizedUser.GetInstance().AuthorizedPerson)
                {
                    await HostApi.GetInstance().EditUser(_User);
                    await Shell.Current.GoToAsync("//Overview");
                }
            });
        }

    }
}
