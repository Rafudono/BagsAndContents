using BagsAndContents.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class NewContentVM
    {
        public Content NeWContent { get; set; } = new Content();
        public VmCommand Save {  get; }
        public NewContentVM()
        {
            Save = new VmCommand(async () =>
            {
                if (NeWContent != null)
                {
                    await DataBase.GetInstance().AddContent(NeWContent);
                    await Shell.Current.GoToAsync("..");
                }
            });
        }

           
    }
}
