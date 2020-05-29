using Microsoft.Toolkit.Uwp.Notifications;
using System;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.UI.Notifications;

namespace LiTENotifications
{
    /// <summary>
    /// Create and show Windows 10 popup notifications.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets the <see cref="ToastNotificationHistory"/> object.
        /// </summary>
        public static ToastNotificationHistory History => ToastNotificationManager.History;

        private readonly ToastNotification toast;

        /// <summary>
        /// Get or set the notification tag.
        /// </summary>
        public string Tag { get => toast.Tag; set => toast.Tag = value; }

        /// <summary>
        /// Get or set the notification group.
        /// </summary>
        public string Group { get => toast.Group; set => toast.Group = value; }

        /// <summary>
        /// Get or set the notification data.
        /// </summary>
        public NotificationData Data { get => toast.Data; set => toast.Data = value; }

        /// <summary>
        /// Get or set the notification expiration.
        /// </summary>
        public DateTimeOffset? ExpirationTime { get => toast.ExpirationTime; set => toast.ExpirationTime = value; }

        /// <summary>
        /// Get or set if the notification should expire on reboot.
        /// </summary>
        public bool ExpiresOnReboot { get => toast.ExpiresOnReboot; set => toast.ExpiresOnReboot = value; }

        /// <summary>
        /// Get or set the notification mirroring behaviour.
        /// </summary>
        public NotificationMirroring NotificationMirroring { get => toast.NotificationMirroring; set => toast.NotificationMirroring = value; }

        /// <summary>
        /// Get or set the notification priority.
        /// </summary>
        public ToastNotificationPriority Priority { get => toast.Priority; set => toast.Priority = value; }

        /// <summary>
        /// Get or set if the notification should show a popup.
        /// </summary>
        public bool SuppressPopup { get => toast.SuppressPopup; set => toast.SuppressPopup = value; }

        /// <summary>
        /// Event fired when the toast is clicked.
        /// </summary>
        public event TypedEventHandler<ToastNotification, object> Activated { add => toast.Activated += value; remove => toast.Activated -= value; }

        /// <summary>
        /// Event fired when the toast is dismissed.
        /// </summary>
        public event TypedEventHandler<ToastNotification, ToastDismissedEventArgs> Dismissed { add => toast.Dismissed += value; remove => toast.Dismissed -= value; }

        /// <summary>
        /// Create a new toast.
        /// </summary>
        /// <param name="content">The content of the toast.</param>
        public Notification(ToastContent content)
        {
            //Crea XML corrispondente e usalo per creare la toast
            var doc = new XmlDocument();
            doc.LoadXml(content.GetContent());
            toast = new ToastNotification(doc)
            {
                Data = new NotificationData()
            };
        }

        /// <summary>
        /// Shows created toast.
        /// </summary>
        public void Show()
        {
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        /// <summary>
        /// Updates the toast.
        /// </summary>
        public void Update()
        {
            ToastNotificationManager.CreateToastNotifier().Update(Data, Tag, Group);
        }
    }
}
