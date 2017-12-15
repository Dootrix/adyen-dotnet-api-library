using System.Runtime.Serialization;

namespace Adyen.EcommLibrary.Model.Notification
{
    /// <summary>
    /// Response to accept notification.
    /// 
    /// Send the response "[accepted]" from your server to the Adyen server within 10 seconds of receiving a notification. 
    /// We recommend that you accept and reply to notifications separately from processing them.
    /// 
    /// After our server receives this response, all items in the notification are marked as received.
    /// 
    /// If the notification delivery fails, or in case it is not possible to determine, from the response, whether the message 
    /// was delivered successfully or not, notifications are sent multiple times. This at-least-once delivery rule means that 
    /// you may receive the same notification multiple times.
    /// 
    /// Example Json: { "notificationResponse" : "[accepted]" }
    ///    
    /// For additional api spec, see: https://docs.adyen.com/developers/payment-notifications#notificationresponseacceptnotifications
    /// </summary>
    public class NotificationResponse
    {
        [DataMember(Name = "notificationResponse", EmitDefaultValue = false)]
        public string Response { get; } = "[accepted]";
    }
}
