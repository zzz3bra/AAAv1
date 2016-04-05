using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class UserRecord
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public List<ADS> FavouriteADS { get; private set; }
        public List<Notification> Notifications { get; private set; }
        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
        public void AddFavouriteADS(ADS ad)
        {
            FavouriteADS.Add(ad);
        }
        public void RemoveNotification(Notification notification)
        {
            Notifications.Remove(notification);
        }
        public void RemoveFavouriteADS(ADS ad)
        {
            FavouriteADS.Remove(ad);
        }
        public UserRecord(int id, string Name, List<ADS> FavouriteADS, List<Notification> Notification)
        {
            this.id = id;
            this.Name = Name;
            this.FavouriteADS = FavouriteADS;
            this.Notifications = Notifications;
        }
    }
}