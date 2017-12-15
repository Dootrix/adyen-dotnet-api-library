using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Adyen.EcommLibrary.Model.Notification
{
    /// <summary>
    /// The Adyen MarketPay system can send you notifications for a set of events during the flow.
    /// 
    /// For api spec, see: https://docs.adyen.com/developers/marketpay/marketpay-notifications
    /// </summary>
    public class NotificationRequest
    {
        /// <value>true, in case of live environment; otherwise, false, in case of test environment.</value>
        [DataMember(Name = "live", EmitDefaultValue = false)]
        public string Live { get; set; }

        [DataMember(Name = "notificationItems", EmitDefaultValue = false)]
        public List<NotificationRequestItemContainer> NotificationItems { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationRequest {\n");
            sb.Append("  Live: ").Append(this.Live).Append("\n");
            sb.Append("  NotificationItems: ").Append(this.NotificationItems).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
