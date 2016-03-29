using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AAAv1.Models
{
    public class AWby : IInformCreator
    {
        private string _data = "";

        public List<ADS> DataParse(string searchData)
        {
            string response = Get("http://public.aw.by/");

            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(response);


            HtmlNodeCollection c = hap.DocumentNode.SelectNodes("//td[@class='link']");


            if (c != null)
            {
                int iter = 1;
                foreach (HtmlNode n in c)
                {
                    if (iter % 2 != 0)
                    {
                        string s = n.InnerHtml;
                        Console.WriteLine(s.Substring(0).Split(new char[1] { '"' })[1]);
                    }
                    iter++;
                }
            }

            return new List<ADS>();
        }

        private string Get(string Url)
        {
            WebRequest req = WebRequest.Create(Url + "?" + _data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }
}
