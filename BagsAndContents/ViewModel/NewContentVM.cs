using BagsAndContents.Model;
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
                var bag = DataBase.GetInstance().GetMyBag();
                if (NeWContent != null)
                {
                    NeWContent.BagId= bag.Id;
                    await DataBase.GetInstance().AddContent(NeWContent);
                    await Shell.Current.GoToAsync("//MyBag");
                }
            });
        }

           
    }
}
