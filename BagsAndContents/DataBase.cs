using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BagsAndContents
{
     class DataBase
    {
        private static DataBase instance;
        private DataBase()
        {
            ReloadBagContent();
            ReloadBagOwners();
        }

        public static DataBase GetInstance()
        {
            if (instance == null)
                instance = new DataBase();
            return instance;
        
        }
        private List<Bag> Bags = new List<Bag>
        {
            new() { Id=1, OwnerId=1, Type="Бежевая сумочка" },
            new() {Id=2, OwnerId=2, Type="Сумка для компа"}
        };
        private List<Content> Contents = new List<Content>
        {
        new () {Id = 1, BagId=2, Name="Ноут", Description = "Очень важная вещьч"},
        new() {Id=2, BagId=1, Name="Расчёска"},
        new() {Id=3, BagId=1, Name="Носки", Description="?"}
        };
        private List<Person> People = new List<Person>
        {
            new() {Id=1, Name="Алёна"},
            new() {Id=2, Name = "neЯ" } };
        public async Task<List<Bag>> GetBags()
        { await Task.Delay(100); return new List<Bag>(Bags); }
        public async Task<List<Content>> GetContents()
        { await Task.Delay(100); return new List<Content>(Contents); }
        public void ReloadBagContent()
        {
            foreach (var bag in Bags)
            {
                bag.BagContents = new();
                foreach (var content in Contents)
                    if (bag.Id == content.BagId)
                    {
                        bag.BagContents.Add(content);
                    }
            }
        }
        public void ReloadBagOwners()
        {
            foreach(var bag in Bags)
            {
                bag.Owner = new();
                foreach(var person in People)
                    if(bag.OwnerId==person.Id)
                        bag.Owner=person;
            }
        }
        public async Task<Bag> GetBagById(int id)
        {
            foreach (Bag b in Bags)
            {
                if (b.Id == id)
                {
                    Bag bag = new Bag
                    {
                        Id = b.Id,
                        OwnerId = b.OwnerId,
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
        { await Task.Delay(100);
            Bag bag = new Bag()
            {
                Id = Bags.Count() + 1,
                Type = b.Type,
                OwnerId = b.OwnerId,
                BagContents= b.BagContents
            };
            Bags.Add(bag); }
        public async void RemoveBag(int bag_id)
        { await Task.Delay(100);
            Bag deleteMe = new Bag();
            foreach (Bag b in Bags)
            {
                if(b.Id == bag_id)
                {
                    deleteMe = b;
                }
            }
            Bags.Remove(deleteMe);
        }
        public async void EditBag (Bag bag)
        {
           
            foreach (Bag b in Bags)
            {
                if (b.Id == bag.Id)
                {
                    b.OwnerId = bag.OwnerId;
                    b.Type= bag.Type;
                    b.BagContents= bag.BagContents;
                }

            }
            await Task.Delay(100);
        }

        public async void AddContent(Content c)
        {
            await Task.Delay(100);
            Content content = new Content()
            {
                Id = Contents.Count() + 1,
                Name = c.Name,
                Description = c.Description,
                BagId = c.BagId,
               
            };
            foreach (Bag bag in Bags)
                if(bag.Id == content.BagId)
                     bag.BagContents.Add(content);
            Contents.Add(content);
        }
        public async Task RemoveContent(int c_id)
        {
            await Task.Delay(100);
            Content deleteMe = new Content();

            foreach (Content c in Contents)
            {
                if (c.Id == c_id)
                {
                    deleteMe = c;
                }
            }
            Contents.Remove(deleteMe);
        }
        public async void EditContent(Content content)
        {
            foreach (Content c in Contents)
            {
                if (c.Id == content.Id)
                {
                    c.Name = content.Name;
                    c.Description = content.Description;
                    c.BagId = content.BagId;
                }

            }
            await Task.Delay(100);
        }

    }
}
