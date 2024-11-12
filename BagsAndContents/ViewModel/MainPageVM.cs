using BagsAndContents.ModelsForApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.ViewModel
{
    public class MainPageVM:BaseVM
    {
        public Bag SelectedBag { get; set; }
        public List<Bag> ListBags { get; set; } = new List<Bag>();
        public MainPageVM()
        {
           
        }
        public async void UpdateCollections()
        {
           
            ListBags = await HostApi.GetInstance().GetBags();
            Signal(nameof(ListBags));
        }

        internal void OnAppearing()
        {
            UpdateCollections();
        }
    }
}

