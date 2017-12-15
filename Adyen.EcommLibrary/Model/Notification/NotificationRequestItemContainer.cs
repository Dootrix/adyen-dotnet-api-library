using System;
using System.Runtime.Serialization;
using System.Text;

namespace Adyen.EcommLibrary.Model.Notification
{
    public class NotificationRequestItemContainer
    {
        /// <remarks>
        /// Capitalised property name.
        /// </remarks>
        [DataMember(Name = "NotificationRequestItem", EmitDefaultValue = false)]
        public NotificationRequestItem NotificationRequestItem { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NotificationRequestItemContainer {\n");

            sb.Append("  NotificationRequestItem: ").Append(ToIndentedString(this.NotificationRequestItem)).Append("\n");
            sb.Append("}");
            return sb.ToString();
        }


        private string ToIndentedString(Object o)
        {
            if (o == null)
            {
                return "null";
            }
            return o.ToString().Replace("\n", "\n    ");
        }

    }
}