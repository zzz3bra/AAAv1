using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class UserBase
    {
        public static UserRecord CurrentUser { get; private set; }
        protected UserBase() { }
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
        public void UpdateUserInfo(int UsedID, List<ADS> FavouriteADS, List<Notification> Notification)
        {
            //изменение предпочтений пользователя, пароль пока не трогаем
        }
        public List<Notification> GetAllNotifications()
        {
            //получаем все уведомления для класса УВЕДОМИТЕЛЬ который собстенно и будет уведомлять
            return new List<Notification>();
        }
    }
}