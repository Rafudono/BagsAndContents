using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class NewContentVM:BaseVM
    {
        private Content neWContent = new Content();

        public Content NeWContent { get => neWContent; set
            {
                neWContent = value;
                Signal();
            }
        }
        public VmCommand Save {  get; }
        public NewContentVM()
        {
            Save = new VmCommand(async () =>
            {
                var bag = HostApi.GetInstance().GetMyBag(AuthorizedUser.GetInstance().AuthorizedPerson);
                if (NeWContent != null)
                {
                    NeWContent.BagId= bag.Id;
                    await HostApi.GetInstance().AddContent(NeWContent);
                    await Shell.Current.GoToAsync("//MyBag");
                }
            });
        }

           
    }
}
