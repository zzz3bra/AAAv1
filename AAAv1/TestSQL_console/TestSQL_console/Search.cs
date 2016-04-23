using System;
using System.Text;

namespace TestSQL_console
{
    class Search
    {
        private string[] searchStringArr;

        private StringBuilder searchString;
        public Search()
        {
            searchStringArr = new string[4];
            searchString = new StringBuilder("");
        }
        private void Check()
        {
            if(searchString.Length>0)
            {
                searchString.Insert(searchString.Length, "AND");
            }
        }
        public void SetMinPrice(int minPrice)
        {
            searchStringArr[0] = "(Price >= " + minPrice.ToString() + ")";
        }
        public void SetMaxPrice(int maxPrice)
        {
            searchStringArr[1] = "(Price <= " + maxPrice.ToString() + ")";
        }
        public void SetCompany(string company)
        {
            searchStringArr[2] = "(Company = '" + company + "')";
        }
        public void SetModel(string model)
        {
            searchStringArr[3] = "(Model = '" + model + "')";
        }
        public string SearchString()
        {
            searchString.Clear();
            for (int i = 0; i < 4; i++)
            {
                if ((searchStringArr[i] != null)&&(searchStringArr[i] != ""))
                {
                    Check();
                    searchString.Insert(searchString.Length, searchStringArr[i]);
                    searchStringArr[i] = null;
                }
            }
            Console.WriteLine("Запрос {0}",searchString.ToString());
            return searchString.ToString();
        }
    }
}
