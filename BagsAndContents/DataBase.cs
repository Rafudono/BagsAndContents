using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class DataBase
    {
        public List<Bag> Bags = new List<Bag>
        {
            new() { Id=1, OwnerName="Алёна", Type="Бежевая сумочка"},
            new() {Id=2, OwnerName="Я", Type="Сумка для компа"}
        };
        public List<Content> Contents = new List<Content>
        {
        new () {Id = 1, BagId=2, Name="Ноут", Description = "Очень важная вещьч"},
        new() {Id=2, BagId=1, Name="Расчёска"},
        new() {Id=3, BagId=1, Name="Носки", Description="?"}
        };
        public DataBase()
        {
            foreach (var bag in Bags)
            {
                foreach (var content in Contents)
                    if (bag.Id == content.BagId)
                    {
                        bag.BagContents.Add(content);
                    }
            }
        }
        public async Task<List<Bag>> GetBags()
        { await Task.Delay(100); return new List<Bag>(Bags); }
        public async Task<List<Content>> GetContents()
        { await Task.Delay(100); return new List<Content>(Contents); }

        public async Task<Bag> GetBagById(int id)
        {
            foreach (Bag b in Bags)
            {
                if (b.Id == id)
                {
                    Bag bag = new Bag
                    {
                        Id = b.Id,
                        OwnerName = b.OwnerName,
                        Type = b.Type,
                        BagContents = b.BagContents
                    };
                    return bag;

                }
            }
            await Task.Delay(100);
            return null;
        }
        public async Task<Content> GetContentById(int id)
        {
            foreach (Content c in Contents)
            {
                if (c.Id == id)
                {
                    Content newContent = new Content();
                    newContent = c;
                    return newContent; 
                }
            }
            await Task.Delay(100);
            return null;
        }

        public async void AddBag(Bag b)
        { await Task.Delay(100); Bags.Add(b); }
        public async void RemoveBag(int bag_id)
        { await Task.Delay(100);
            foreach (Bag b in Bags)
            {
                if(b.Id == bag_id)
                {
                    Bag delBag = new Bag();
                    delBag = b;
                    Bags.Remove(delBag);
                }
            }
        }
        public async void EditBag (Bag bag)
        {
            foreach (Bag b in Bags)
            {
                if (b.Id == bag.Id)
                { 
                    Bag editedbag = new Bag();
                    editedbag = bag;
                    b.OwnerName=editedbag.OwnerName;
                    b.Type=editedbag.Type;
                    b.BagContents= editedbag.BagContents;
                }

            }
            await Task.Delay(100);
        }

        public async void AddContent(Content content)
        { await Task.Delay(100); 
            Contents.Add(content); }
        public async void RemoveContent(Content content)
        { await Task.Delay(100); Contents.Remove(content); }
    }
}
