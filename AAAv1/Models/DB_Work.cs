using System;
using System.Data.SqlClient;

namespace AAAv1.Models
{
    public class DB_Work : IDisposable
    {
        public static string carsTable = "Cars";
        public static string favoritesTable = "Favorites";
        public static string usersTable = "Users";

        private static SqlConnection _sql_connect;
        private SqlCommand cmdSQL;
        SqlDataReader reader;
        private string commandString;

        //public void OnClickFavoriteButton(string UserEmail, CarAD AD)
        //{
        //    if (isCarExist)
        //    {
        //        AddFavorite(UserEmail, AD.URLAddress);
        //    }
        //    else
        //    {
        //        AddNewCar(AD.Manufacturer, AD.Model, AD.Price, AD.PhoneNumber, AD.URLAddress);
        //        AddFavorite(UserEmail, AD.URLAddress);
        //    }
        //}

        public DB_Work(string connection)
        {
            _sql_connect = new SqlConnection(connection);
        }

        private void Connect(string command)
        {
            cmdSQL = new SqlCommand(command, _sql_connect);
            try
            {
                _sql_connect.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка соединения");
            }
            if (_sql_connect.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Соединение установлено");
            }
        }

        public bool isCarExist(string URL)
        {
            commandString = "SELECT * FROM " + favoritesTable + " WHERE (Car_ID=" + FindCarID(URL).ToString() + ")";
            Connect(commandString);
            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                DeleteRow(carsTable, FindCarID(URL));
                return false;
            }
        }

        public void AddNewCar(string Company, string Model, string Price, string PhoneNumber, string URL)
        {
            commandString = "INSERT INTO " + carsTable + " (Company,Model,Price,PhoneNumber,URL) VALUES ('" + Company + "','" + Model + "','" + Price + "','" + PhoneNumber + "','" + URL + "')";

            Connect(commandString);

            cmdSQL.ExecuteNonQuery();
            Console.WriteLine("Строка добавлена");
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }
        public void AddNewUser(string Email, string Pass)
        {
            commandString = "INSERT INTO " + usersTable + " (Pass,Email) VALUES ('" + Pass + "','" + Email + "')";

            Connect(commandString);

            cmdSQL.ExecuteNonQuery();
            Console.WriteLine("Пользователь добавлен");
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }
        public void RemoveUser(string Email)
        {
            commandString = "DELETE FROM " + usersTable + " WHERE (Email=" + Email + ")";

            Connect(commandString);

            cmdSQL.ExecuteNonQuery();
            Console.WriteLine("Пользователь удален");
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }
        public void AddFavorite(string UserEmail, string CarURL)
        {
            commandString = "INSERT INTO " + favoritesTable + " (User_ID,Car_ID) VALUES ('" + FindUserID(UserEmail).ToString() + "','" + FindCarID(CarURL).ToString() + "')";

            Connect(commandString);

            cmdSQL.ExecuteNonQuery();
            Console.WriteLine("Объявление добавлено в избранные");
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }

        private int FindCarID(string URL)
        {
            int result = -1;
            commandString = "SELECT * FROM " + carsTable + " WHERE URL='" + URL + "'";

            Connect(commandString);

            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            reader.Close();
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
            return result;
        }
        private int FindUserID(string Email)
        {
            int result = -1;
            commandString = "SELECT * FROM " + usersTable + " WHERE Email='" + Email + "'";

            Connect(commandString);

            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            reader.Close();
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
            return result;
        }
        public void Search(string Table, string searchString)
        {
            Console.WriteLine("Поиск строк");
            if ((searchString != "") && (searchString != null))
            {
                commandString = "SELECT * FROM " + Table + " WHERE " + searchString;
            }
            else
            {
                commandString = "SELECT * FROM " + Table;
            }

            Connect(commandString);

            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("ID: {0} \nCompany: {1} \nModel: {2} \nPrice: {3} \nPhoneNumber: {4} \nURL: {5}",
                        reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                        reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Строки отсутствуют");
            }

            reader.Close();
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }
        public int CheckUser(string Email, string pass)
        {
            int result = -1;
            commandString = "SELECT * FROM " + usersTable + " WHERE (ID=" + FindUserID(Email) + ") AND (Pass='" + pass + "')";

            Connect(commandString);

            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            reader.Close();
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
            return result;
        }

        private void DeleteRow(string Table, int ID)
        {
            commandString = "DELETE " + Table + " WHERE ID = " + ID.ToString();

            Connect(commandString);

            cmdSQL.ExecuteNonQuery();
            Console.WriteLine("Строка удалена");
            _sql_connect.Close();
            Console.WriteLine("Соединение закрыто");
        }
        public void DeleteCar(string URL)
        {
            DeleteRow(carsTable, FindCarID(URL));
        }
        public void DeleteFav(string carURL, string userEmail)
        {
            commandString = "SELECT * FROM " + favoritesTable + " WHERE (User_ID=" + FindUserID(userEmail).ToString() + ")AND(Car_ID=" + FindCarID(carURL).ToString();

            Connect(commandString);

            reader = cmdSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeleteRow(favoritesTable, reader.GetInt32(0));
                }
            }
            reader.Close();
            _sql_connect.Close();
        }

        public void Dispose()
        {
            _sql_connect.Close();
            _sql_connect.Dispose();
        }
    }
}