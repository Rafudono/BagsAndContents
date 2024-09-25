using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class Bag
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }
        public string Type { get; set; }
        public List<Content> BagContents { get; set; }=new List<Content>();  
    }
}
