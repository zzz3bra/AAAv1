using System;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AAAv1.Models
{
    class SuperParser
    {
        private string _dataonliner = "";

        public SuperParser(string data_onliner)
        {
            _dataonliner = data_onliner;
        }

        public List<JsonAds> GetAdsOnliner()
        {
            var j = JObject.Parse(Post_Onliner(_dataonliner));
            var q = j["result"]["advertisements"].ToList();


            List<JsonAds> searchResults = new List<JsonAds>();
            foreach (JToken result in q)
            {
                JsonAds searchResult = JsonConvert.DeserializeObject<JsonAds>(result.First.ToString());
                searchResults.Add(searchResult);
            }


            //return ConvertToNormalADS.ConvADS(searchResults); // НЕ ТРОГАТЬ!!! ПОТОМ ЗАРАБОТАЕТ!!!
            return searchResults;
        }

        private string Post_Onliner(string data)
        {
            WebRequest req = WebRequest.Create(@"http://ab.onliner.by/search#");
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(data);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
    }
}

