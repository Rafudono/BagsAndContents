using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents.Model
{
    public class Bag
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public Person Owner { get; set; } = new Person();
        public string? Type { get; set; } = "";

        [NotMapped]
        public List<Content> BagContents { get; set; } = new List<Content>();
    }
}
