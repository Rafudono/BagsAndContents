using BagsAndContents.ModelsForApi;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class HostApi
    {//здеся все методы принятые из api
        public HostApi()
        {
            options = new JsonSerializerOptions { ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles };
            httpClient.BaseAddress = new Uri("http://10.0.2.2:5139/api/");
        }

        JsonSerializerOptions options = new JsonSerializerOptions();

        HttpClient httpClient = new HttpClient();

        private static HostApi instance;
        public static HostApi GetInstance()
        {
            if (instance == null)
                instance = new HostApi();
            return instance;
        }

        public List<User> Users { get; set; }
        public List<Bag> Bags { get; set; }
        public List<Content> Contents { get; set; }
        internal async Task AddBag(Bag bag)
        {
            var arg = JsonSerializer.Serialize(bag);
            var responce = await httpClient.PostAsync($"BagsNContents/AddBag", 
                new StringContent(arg, Encoding.UTF8, "application/json"));
            var wh = responce.StatusCode;
            var t = wh;
        }

        internal async Task EditBag(Bag bag)
        {
            var arg = JsonSerializer.Serialize(bag);
            var responce = await httpClient.PostAsync($"BagsNContents/EditBag", 
                new StringContent(arg, Encoding.UTF8, "application/json"));
        }

        internal async Task<User> IsUserRegistred(SearchUserByLoginAndPassword searchData)
        {
            User user = new();
            var arg = JsonSerializer.Serialize(searchData);
            var responce = await httpClient.PostAsync($"BagsNContents/Auth",
                   new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                user = await responce.Content.ReadFromJsonAsync<User>();
            }
            return user;
        }

        internal async Task<Bag> GetMyBag(User user)
        {
            Bag myBag = new Bag();
            var arg = JsonSerializer.Serialize(user);
            var responce = await httpClient.PostAsync($"BagsNContents/GetMyBag",
                   new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
               myBag = await responce.Content.ReadFromJsonAsync<Bag>();
            }
            return myBag;
        }

        internal async Task AddContent(Content neWContent)
        {
            var arg = JsonSerializer.Serialize(neWContent);
            var responce = await httpClient.PostAsync($"BagsNContents/AddContent",
                new StringContent(arg, Encoding.UTF8, "application/json"));
            var wh = responce.StatusCode;
            var t = wh;
        }

        internal async Task<List<Bag>> GetBags()
        {
            var responce = await httpClient.PostAsync($"BagsNContents/GetBags",
                   new StringContent("{}", Encoding.UTF8, "application/json"));
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Bags = await responce.Content.ReadFromJsonAsync<List<Bag>>();
            }
            return Bags;
        }

        internal async Task RemoveContent(Content delContent)
        {
            var arg = JsonSerializer.Serialize(delContent);
            var responce = await httpClient.PostAsync($"BagsNContents/RemoveContent",
                new StringContent(arg, Encoding.UTF8, "application/json"));
        }

        internal async Task EditUser(User user)
        {
            var arg = JsonSerializer.Serialize(user);
            var responce = await httpClient.PostAsync($"BagsNContents/EditUser",
                   new StringContent(arg, Encoding.UTF8, "application/json"));
        }
        
        internal async Task AddUser(User user)
        {
            var arg = JsonSerializer.Serialize(user);
            var responce = await httpClient.PostAsync($"BagsNContents/AddUser",
                   new StringContent(arg, Encoding.UTF8, "application/json"));
        }
    }
}
