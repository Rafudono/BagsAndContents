using System;
using System.Collections.Generic;
using System.Linq;
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
            //здесь мы создадим список пакетов и их содержимого
            //а также добавим работу с ними (функционал)
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
        { await Task.Delay(100); return Bags; }
        public async Task<List<Content>> GetContents()
        { await Task.Delay(100); return Contents; }

        public async Task<Bag> GetBagById(int id)
        {
            foreach (Bag b in Bags)
            {
                b.Id = id;
                return b;
            }
            await Task.Delay(100);
            return null;
        }
        public async Task<Content> GetContentById(int id)
        {
            foreach (Content c in Contents)
            {
                c.Id = id;
                return c;
            }
            await Task.Delay(100);
            return null;
        }

        public async void AddBag(Bag b)
        { await Task.Delay(100); Bags.Add(b); }
        public async void RemoveBag(Bag b)
        { await Task.Delay(100); Bags.Remove(b); }

        public async void AddContent(Content content)
        { await Task.Delay(100); Contents.Add(content); }
        public async void RemoveContent(Content content)
        { await Task.Delay(100); Contents.Remove(content); }
    }
}
