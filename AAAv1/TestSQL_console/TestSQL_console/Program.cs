using System;

namespace TestSQL_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connect_string = @"Data Source=localhost;AttachDbFilename=C:\Users\Станислав\TestDataBase.mdf;Integrated Security=true";

            using (DB_Work dbw = new DB_Work(connect_string))
            {
                string user = "email";
                string pass = "pass";
                if (dbw.CheckUser(user, pass) == -1)
                {
                    dbw.AddNewUser(user, pass);
                }
                Console.WriteLine(dbw.CheckUser(user, pass));
            }
            //Search srch = new Search();

            //srch.SetMinPrice(2500);
            //srch.SetMinPrice(2500);
            //srch.SetMaxPrice(40000);
            //srch.SetMaxPrice(40000);

            //dbw.Search(DB_Work.carsTable, srch.SearchString());
            //dbw.Search(DB_Work.usersTable, srch.SearchString());
            //dbw.AddNewUser("TestUser2", "TestEmail2");
            //dbw.AddNewCar("Honda", "Civic", "5000", "+375291234567", "test.by");
            //dbw.AddFavorite(7, 8006);
            //dbw.DeleteRow(DB_Work.carsTable, 8004);

            //dbw.Search(DB_Work.carsTable, srch.SearchString());

            Console.WriteLine("Нажать enter для выхода...");

            Console.ReadLine();
        }
    }
}
