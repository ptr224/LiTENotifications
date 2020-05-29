using Microsoft.Toolkit.Uwp.Notifications;
using System;

namespace LiTENotifications
{
    /// <summary>
    /// Create and show text only popup notifications.
    /// </summary>
    public class SimpleNotification : Notification
    {
        /// <summary>
        /// Create a text only notification.
        /// </summary>
        /// <param name="args">Notification arguments.</param>
        /// <param name="text">Notification text.</param>
        public SimpleNotification(string args, string text)
            : base(new ToastContent()
            {
                Launch = args,

                Visual = new ToastVisual
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = text
                            }
                        }
                    }
                }
            })
        { }

        /// <summary>
        /// Create a text only notification with title.
        /// </summary>
        /// <param name="args">Notification arguments.</param>
        /// <param name="title">Notification title.</param>
        /// <param name="text">Notification text.</param>
        public SimpleNotification(string args, string title, string text)
            : base(new ToastContent()
            {
                Launch = args,

                Visual = new ToastVisual
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title
                            },

                            new AdaptiveText()
                            {
                                Text = text
                            }
                        }
                    }
                }
            })
        { }

        /// <summary>
        /// Create a text only notification with title and a thumbnail image.
        /// </summary>
        /// <param name="args">Notification arguments.</param>
        /// <param name="title">Notification title.</param>
        /// <param name="text">Notification text.</param>
        /// <param name="image">Notification image path.</param>
        public SimpleNotification(string args, string title, string text, Uri image)
            : base(new ToastContent()
            {
                Launch = args,

                Visual = new ToastVisual
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = image.AbsoluteUri,
                            HintCrop = ToastGenericAppLogoCrop.None
                        },

                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title
                            },

                            new AdaptiveText()
                            {
                                Text = text
                            }
                        }
                    }
                }
            })
        { }
    }
}
