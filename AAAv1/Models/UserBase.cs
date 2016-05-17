using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class UserBase
    {
        public static UserRecord CurrentUser { get; private set; }
        public static UserRecord MockUser { get; private set; }
        protected UserBase()
        {
            MockUser = new UserRecord(-1, "Kanjodriver", new List<ADS>(), new List<Notification>());
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
        public UserRecord GetUserByCredentials(string account, string password)
        {
            //запрос в базу, поиск юзера и возврат его в виде объекта
            return new UserRecord(1, "AGL", new List<ADS>(), new List<Notification>());
        }
        public void RemoveUserAccountById(int UserID)
        {
            //удаление юзера из базы
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