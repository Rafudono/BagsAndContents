using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class HostApi
    {//здеся все методы принятые из api
        public HostApi()
        {
            httpClient.BaseAddress = new Uri("http://10.0.2.2:5139");
        }
        HttpClient httpClient = new HttpClient();
        private static HostApi instance;
        public static HostApi GetInstance()
        {
            if (instance == null)
                instance = new HostApi();
            return instance;
        }

    }
}
