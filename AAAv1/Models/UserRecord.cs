using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class UserRecord
    {
        public int id { get; private set; }
        public string Email { get; private set; }
        public List<ADS> currentADS { get; set; }
        public List<ADS> FavouriteADS { get; private set; }
        public List<Notification> Notifications { get; private set; }
        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
        public void RemoveNotification(Notification notification)
        {
            Notifications.Remove(notification);
        }
        public void AddFavouriteADS(ADS ad)
        {
            FavouriteADS.Add(ad);
        }
        public void RemoveFavouriteADS(ADS ad)
        {
            FavouriteADS.Remove(ad);
        }
        public ADS GetIdealCar()
        {
            //сложная логика по подбору авто или вызов хранимки
            ADS idealCar = new ADS();
            idealCar.Car = new Car() { Model = new Model() { ManufacturerName = "Honda", Name = "Civic" } };
            return idealCar;
        }
        public UserRecord(int id, string Email, List<ADS> FavouriteADS, List<Notification> Notifications)
        {
            this.id = id;
            this.Email = Email;
            this.FavouriteADS = FavouriteADS;
            this.Notifications = Notifications;
        }
    }
}