
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BagsAndContents.Model
{
    class DataBase
    {
        ContextDb context = new ContextDb("BagsApplicationDataBase");
        private static DataBase instance;
        private DataBase()
        {
            context.Database.EnsureCreated();
            //ReloadBagContent();
            //ReloadBagOwners();
        }

        public static DataBase GetInstance()
        {
            if (instance == null)
                instance = new DataBase();
            return instance;

        }
        private List<Bag> Bags = new List<Bag>();
        //new List<Bag>
        //{
        //    new() { Id=1, OwnerId=1, Type="Бежевая сумочка" },
        //    new() {Id=2, OwnerId=2, Type="Сумка для компа"}
        //};
        private List<Content> Contents = new List<Content>
        {
            //new () {Id = 1, BagId=2, Name="Ноут", Description = "Очень важная вещьч"},
            //new() {Id=2, BagId=1, Name="Расчёска"},
            //new() {Id=3, BagId=1, Name="Носки", Description="?"}
        };
        private List<Person> People = new List<Person>
        {
            //new() {Id=1, Name="Алёна", Login = "al", Password = "al"},
            //new() {Id=2, Name = "neЯ", Login="raf", Password="r" } 
        };
        public async Task<List<Bag>> GetBags()
        {
            await Task.Delay(100);
            Bags = context.Bags.ToList();
            return new List<Bag>(Bags);
        }
        public async Task<List<Content>> GetContents()
        {
            await Task.Delay(100);
            Contents = context.Contents.ToList();
            return new List<Content>(Contents);
        }
        //public void ReloadBagContent()
        //{
        //    foreach (var bag in Bags)
        //    {
        //        bag.BagContents = new();
        //        foreach (var content in Contents)
        //            if (bag.Id == content.BagId)
        //            {
        //                bag.BagContents.Add(content);
        //            }
        //    }
        //}
        //public void ReloadBagOwners()
        //{
        //    foreach(var bag in Bags)
        //    {
        //        bag.Owner = new();
        //        foreach(var person in People)
        //            if(bag.OwnerId==person.Id)
        //                bag.Owner=person;
        //    }
        //}
        public async Task<Bag> GetBagById(int id)
        {
            await Task.Delay(100);
            var b = context.Bags.Where(s => s.Id == id).FirstOrDefault();
            if (b != null)
                return b;
            else

                //ошибка но как я буду дисплей алерт писать здесь...
                return b;

        }
        public async Task<Content> GetContentById(int id)
        {
            await Task.Delay(100);
            return context.Contents.Where(s => s.Id == id).FirstOrDefault();
        }

        public async void AddBag(Bag b)
        {
            await Task.Delay(100);
            Bag bag = new Bag();
            context.Bags.Add(bag);
            context.SaveChanges();
        }
        public async void RemoveBag(int bag_id)
        {
            await Task.Delay(100);
            var b = GetBagById(bag_id);
            var deleteme = b.Result;
            context.Bags.Remove(deleteme);
            context.SaveChanges();
        }
        public async void EditBag(Bag bag)
        {

            await Task.Delay(100);
            Bag bag1 = new Bag();
            context.Bags.Update(bag1);
            context.SaveChanges();

        }

        public async void AddContent(Content c)
        {
            await Task.Delay(100);
            Content content = new Content();
            context.Contents.Add(content);
            context.SaveChanges();

        }
        public async Task RemoveContent(int c_id)
        {
            await Task.Delay(100);
            var c = GetContentById(c_id);
            var deleteme = c.Result;
            context.Contents.Remove(deleteme);
            context.SaveChanges();

        }
        public async Task<Person> IsUserRegistred(string login, string pswd)
        {
            await Task.Delay(100);
            var reg = context.People.Where(s => s.Password == pswd && s.Login == login).FirstOrDefault();
            return reg;
        }
        public async void AddUser(Person person)
        {
            await Task.Delay(100);
            Person p = new Person();
            context.People.Add(p);
            context.SaveChanges();
        }
        public async void EditUser(Person person)
        {

            await Task.Delay(100);
            context.People.Update(person);
            context.SaveChanges();
        }
        public async Task RemoveUser(int u_id)
        {
            await Task.Delay(100);
            Person deleteMe = new Person();
            var p = context.People.Where(s => s.Id == u_id).FirstOrDefault();
            var deleteme = p;
            context.People.Remove(deleteme);
            context.SaveChanges();
        }
    }
}
