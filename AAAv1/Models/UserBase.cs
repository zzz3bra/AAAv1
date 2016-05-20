using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class UserBase
    {
        private static string connect_string = @"Data Source=localhost;AttachDbFilename=C:\Users\Станислав\TestDataBase.mdf;Integrated Security=true";
        private static DB_Work dbWorker;
        public UserRecord CurrentUser { get; set; }
        public static UserRecord MockUser { get; private set; }
        protected UserBase()
        {
            //MockUser = new UserRecord(-1, "Kanjodriver", new List<ADS>(), new List<Notification>());
            dbWorker = new DB_Work(connect_string);
        }
        public static UserBase Instance
        {
            get
            {
                return UserBaseCreator.Instance;
            }
        }

        private sealed class UserBaseCreator
        {
            private static readonly UserBase instance = new UserBase();
            public static UserBase Instance
            {
                get { return instance; }
            }
        }
        public UserRecord GetUserByCredentials(string email, string password)
        {
            int userID = dbWorker.CheckUser(email, password);
            if (userID == -1)
            {
                return null;
            }
            // нужен метод по доставанию списков юзера
            return new UserRecord(userID, email, new List<ADS>(), new List<Notification>());
        }
        public int AddUser(string email, string password)
        {
            if (dbWorker.CheckUser(email, password) != -1)
            {
                return -1;
            }
            dbWorker.AddNewUser(email, password);
            return dbWorker.CheckUser(email, password);
        }
        public void RemoveUserAccount(string email)
        {
            dbWorker.RemoveUser(email);
        }
        public void UpdateUserInfo(UserRecord userRecord)
        {
            //изменение предпочтений пользователя, пароль пока не трогаем
        }
        public List<Notification> GetAllNotifications()
        {
            //получаем все уведомления для класса УВЕДОМИТЕЛЬ который собственно и будет уведомлять
            return new List<Notification>();
        }
    }
}