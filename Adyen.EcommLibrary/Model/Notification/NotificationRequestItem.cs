using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Adyen.EcommLibrary.Model.Notification
{
    /// <summary>
    /// For api spec, see: https://docs.adyen.com/developers/api-reference/notifications-api/notificationrequestitem
    /// </summary>
    public class NotificationRequestItem
    {
        /// <summary>
        /// A container object for the payable amount information for the transaction.
        /// In case of HTTP POST notifications, currency and value are returned as URL parameters.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// The type of event the notification item refers to.
        /// 
        /// When eventCode returns AUTHORISATION, it does not necessarily mean that the payment authorisation request has
        /// been successfully processed.
        /// The authorisation is successful if success = true.
        /// 
        /// If success = false, check the the reason value for further information on the authorisation failure cause.
        /// 
        /// This can occur, for example, if an error occurs or if the transaction is refused.
        /// </summary>
        [DataMember(Name = "eventCode", EmitDefaultValue = false)]
        public string EventCode { get; set; }

        /// <summary>
        /// The time when the event was generated.
        /// - Format: ISO 8601;  YYYY-MM-DDThh:mm:ss.sssTZD
        /// - Example: "2017-10-20T15:29:41+02:00"
        /// </summary>
        [DataMember(Name = "eventDate", EmitDefaultValue = false)]
        public string EventDate { get; set; }

        /// <summary>
        /// The merchant account identifier used in the transaction the notification item refers to.
        /// </summary>
        [DataMember(Name = "merchantAccountCode", EmitDefaultValue = false)]
        public string MerchantAccountCode  { get; set; }

        /// <summary>
        /// A reference to uniquely identify the payment. 
        /// This reference is used in all communication with you about the payment status.
        /// We recommend using a unique value per payment; however, it is not a requirement.
        /// 
        /// If you need to provide multiple references for a transaction, you can enter them in this field.
        /// Separate each reference value with a hyphen character ("-").
        /// 
        /// This field has a length restriction: you can enter max. 80 characters.
        /// 
        /// By default, merchantReference is always returned with payment notifications,
        /// as merchantReference returns the reference field value of the corresponding payment request.
        /// In this case, returned by default = yes
        /// 
        /// Modification requests do not require sending a merchant reference value along with the call.
        /// Therefore, the corresponding notifications do not include it by default.
        /// In this case, returned by default = no
        /// 
        /// An empty merchantReference field in a notification message takes null as a value.
        /// </summary>
        [DataMember(Name = "merchantReference", EmitDefaultValue = false)]
        public string MerchantReference { get; set; }

        /// <summary>
        /// 1) If the notification item is about a	Modification request, then:
        ///
        /// The originalReference value corresponds to the  pspReference value assigned to the original payment.
        /// You receive the pspReference with:
        /// - The payment status, or
        /// - The authorisation notification.
        /// 
        /// 2) If the notification item is about a Payment / Payment authorisation, then this field is not populated, it is blank.
        /// </summary>
        [DataMember(Name = "originalReference", EmitDefaultValue = false)]
        public string OriginalReference { get; set; }

        /// <summary>
        /// Adyen's 16-digit unique reference associated with the transaction/the request. This value is globally unique; quote it
        /// when communicating with us about this request.
        /// - In REPORT_AVAILABLE response you receive a file name in this field.
        /// - In PAIDOUT_REVERSED event code pspsreference is for Capture's pspsreference.
        /// </summary>
        [DataMember(Name = "pspReference", EmitDefaultValue = false)]
        public string PspReference { get; set; }

        /// <summary>
        /// This field is included only in some notifications.
        /// 
        /// This field holds plain text.The value varies depending on whether the outcome of the event is successful or not 
        /// (success = true or false):
        /// 
        /// 1) eventCode = AUTHORISATION, success = true, paymentMethod = visa, mc or amex:
        /// Reason includes the following details:
        /// - Authorisation code
        /// - Last 4 digits of the card
        /// - Card expiry date
        /// Format: 6-digit auth code:last 4 digits:expiry date Card expiry date
        /// Example: 874574:1935:11/2012
        /// 
        /// 2) success = false:
        /// Reason includes a short message with an explanation for the refusal.
        /// 
        /// 3) eventCode = REPORT_AVAILABLE:
        /// Reason includes the download URL where you can obtain a copy of the report.
        /// 
        /// 4) eventCode = PAIDOUT_REVERSED:
        /// Reason field in the notification contains the bank statement description if present, else it contains PaidOutReversed.
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// Informs about the outcome of the event (eventCode) the notification refers to:
        /// 
        /// - true:  the event (eventCode) the notification refers to was executed successfully.
        /// - false: the event was not executed successfully.
        /// 
        /// When eventCode returns AUTHORISATION , it does not necessarily mean that the payment authorisation request has been
        /// successfully processed.
        /// 
        /// The authorisation is successful if success = true.
        /// 
        /// If success = false, check the the reason value for further information on the authorisation failure cause.
        /// This can occur, for example, if an error occurs or if the transaction is refused.
        /// </summary>
        [DataMember(Name = "success", EmitDefaultValue = false)]
        public bool Success { get; set; }

        /// <summary>
        /// The payment method used in the transaction the notification item refers to.
        /// 
        /// Example payment methods that can be set to this field:
        /// visa, mc, ideal, elv, wallie, and so on.
        /// 
        /// This field is populated only in authorisation notifications.
        /// </summary>
        [DataMember(Name = "paymentMethod", EmitDefaultValue = false)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// This field holds a list of the modification operations supported by the transaction the notification item refers to.
        /// 
        /// The available operations in the list give information on the follow-up actions concerning the payment.
        /// You may be requested to:
        /// - Capture the payment (for example, if auto-capture is not set up),
        /// - Cancel the payment (if the payment has not been captured yet), or
        /// - Refund the payment (if the payment has already been captured).
        /// 
        /// Possible values:
        /// - CANCEL
        /// - CAPTURE
        /// - REFUND
        /// 
        /// This field is populated only in authorisation notifications.
        /// 
        /// In case of HTTP POST notifications, the operation list is a sequence of comma-separated string values.
        /// </summary>
        [DataMember(Name = "operations", EmitDefaultValue = false)]
        public List<string> Operations { get; set; }

        /// <summary>
        /// The additionalData object is a generic container that can hold extra fields.
        /// It contains the following elements:
        /// - shopperReference
        /// - shopperEmail
        /// - authCode
        /// - cardSummary
        /// - expiryDate
        /// - authorisedAmountValue
        /// - authorisedAmountCurrency
        /// </summary>
        [DataMember(Name = "additionalData", EmitDefaultValue = false)]
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}