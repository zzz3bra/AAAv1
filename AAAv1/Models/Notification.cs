using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class Notification
    {
        public Notification(string Email, long SecondsBetweenNotifications)
        {
            this.Email = Email;
            this.SecondsBetweenNotifications = SecondsBetweenNotifications;
            Notifications = new List<string>();
            LastSendTime = new DateTime();
        }
        public string Email { get; private set; }
        public long SecondsBetweenNotifications { get; set; }
        public List<string> Notifications { get; private set; }
        public DateTime LastSendTime { get; private set; }
        public bool Enabled { get; set; }
        public void Send()
        {
            //send email
            LastSendTime = DateTime.Now;
        }
        public void AddNotification(string notification)
        {
            Notifications.Add(notification);
        }
    }
}