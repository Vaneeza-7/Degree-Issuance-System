using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectse
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public void SendNotification() { }
        public void ViewNotification() { }
    }
}