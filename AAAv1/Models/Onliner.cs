using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AAAv1.Models
{
    public class Onliner
    {
        private string _data = "";

        public List<ADS> DataParse(string searchData)
        {
            return GetAdsOnliner();
        }

        private string PostRequest()
        {
            WebRequest req = WebRequest.Create(@"http://ab.onliner.by/search#");
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(_data);
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

        private List<ADS> GetAdsOnliner()
        {
            var ads = JObject.Parse(PostRequest())["result"]["advertisements"].ToList();

            List<ADS> searchResults = new List<ADS>();

            foreach (JToken result in ads)
            {
                ADS searchResult = JsonConvert.DeserializeObject<ADS>(result.First.ToString());
                searchResults.Add(searchResult);
            }

            return searchResults;
        }
    }
}