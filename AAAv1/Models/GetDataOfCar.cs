using System.Collections.Generic;

namespace AAAv1.Models
{
    class GetDataOfCar
    {
        public List<ADS> GetADS(string search_data)
        {
            List<ADS> ads = new List<ADS>();

            AWby aw = new AWby();
            Onliner onliner = new Onliner();

            ads.AddRange(aw.DataParse(""));
            ads.AddRange(onliner.DataParse(""));

            return ads;
        }

    }
}

