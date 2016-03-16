using System;
using System.Linq;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Events;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Domain.Store.Model;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Core.Settings;

namespace Ingeniux.ClontechExtension.Module.Observers
{
	public class ExtendedOrderNotificationObserver : IObserver<OrderChangeEvent>
    {
        private readonly INotificationManager _notificationManager;
        private readonly IStoreService _storeService;
        private readonly IContactService _contactService;
        private readonly IOrganizationService _organizationService;

        private readonly ISettingsManager _settingsManager;

        private const string _copyEmailsSettingName = "ProffsExtension.Notifications.CopyEmails";
        private const string _isSendingToUserSettingName = "ProffsExtension.Notifications.IsSendingToUser";

        public ExtendedOrderNotificationObserver(
            INotificationManager notificationManager,
            IStoreService storeService,
            IContactService contactService,
            IOrganizationService organizationService,
            ISettingsManager settingsManager)
        {
            _notificationManager = notificationManager;
            _storeService = storeService;
            _contactService = contactService;
            _organizationService = organizationService;

            _settingsManager = settingsManager;
        }

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(OrderChangeEvent value)
        {
            ////Collection of order notifications
            //var notifications = new List<EmailNotification>();

            //var store = _storeService.GetById(value.ModifiedOrder.StoreId);

            //if (IsOrderCanceled(value))
            //{
            //    var notification = _notificationManager.GetNewNotification<CancelOrderEmailNotification>(value.ModifiedOrder.StoreId, "Store", store.DefaultLanguage);
            //    notification.OrderNumber = value.ModifiedOrder.Number;
            //    notification.CancelationReason = value.ModifiedOrder.CancelReason;

            //    notifications.Add(notification);
            //}

            //if (value.ChangeState == EntryState.Added)
            //{
            //    var notification = _notificationManager.GetNewNotification<Models.OrderCreateEmailNotification>(value.ModifiedOrder.StoreId, "Store", store.DefaultLanguage);
            //    notification.OrderNumber = value.ModifiedOrder.Number;
            //    notification.OrderDate = DateTime.UtcNow;

            //    var address = value.ModifiedOrder.Addresses.FirstOrDefault(a => a.AddressType == VirtoCommerce.Domain.Commerce.Model.AddressType.Billing || a.AddressType == VirtoCommerce.Domain.Commerce.Model.AddressType.BillingAndShipping);

            //    var cultureInfo = CultureInfo.GetCultureInfo(store.DefaultLanguage);
            //    var numberFormat = cultureInfo.NumberFormat.Clone() as NumberFormatInfo;
            //    numberFormat.NumberDecimalDigits = 2;
            //    numberFormat.CurrencyDecimalDigits = 2;

            //    notification.CustomerAddress = new Dictionary<string, string>
            //    {
            //        { "first_name", address.FirstName },
            //        { "last_name", address.LastName },
            //        { "line1", address.Line1 },
            //        { "postal_code", address.PostalCode },
            //        { "city", address.City },
            //        { "country", address.CountryName }
            //    };

            //    notification.IsOrganization = !string.IsNullOrEmpty(value.ModifiedOrder.OrganizationId);

            //    if (notification.IsOrganization)
            //    {
            //        var organization = _organizationService.GetById(value.ModifiedOrder.OrganizationId);

            //        notification.CustomerPhone = organization.Phones.First();
            //        notification.OrganizationNumber = (string)organization.DynamicProperties.First(d => d.Name.Equals("OrganizationNumber", StringComparison.InvariantCultureIgnoreCase)).Values.First().Value;
            //    }

            //    var paymentMethod = store.PaymentMethods.First(p => p.Code.Equals(value.ModifiedOrder.InPayments.First().GatewayCode));
            //    var shippingMethod = store.ShippingMethods.First(s => s.Code.Equals(value.ModifiedOrder.Shipments.First().ShipmentMethodCode));

            //    notification.PaymentType = paymentMethod.Name;
            //    notification.ShipmentType = shippingMethod.Name;

            //    var lineItems = new List<Dictionary<string, string>>();

            //    foreach(var lineItem in value.ModifiedOrder.Items)
            //    {
            //        lineItems.Add(new Dictionary<string, string> {
            //            { "sku", lineItem.Sku },
            //            { "name", lineItem.Name },
            //            { "quantity", lineItem.Quantity.ToString() },
            //            { "tax_rate", (lineItem.TaxDetails.First().Rate * 100).ToString(numberFormat) },
            //            { "total_tax", lineItem.Tax.ToString("C", numberFormat) },
            //            { "total_exkl_tax", lineItem.Price.ToString("C", numberFormat) },
            //            { "total_inkl_tax", (lineItem.Price + lineItem.Tax).ToString("C", numberFormat) }
            //        });
            //    }

            //    notification.LineItems = lineItems.ToArray();

            //    notification.LineItemsTotal = value.ModifiedOrder.Items.Sum(i => i.Price + i.Tax).ToString("C", numberFormat);
            //    notification.PaymentTotal = "kr 0.00";
            //    notification.ShipmentTotal = (value.ModifiedOrder.Shipments.First().Sum - value.ModifiedOrder.Shipments.First().DiscountAmount).ToString("C", numberFormat);
            //    notification.OrderTotal = value.ModifiedOrder.Sum.ToString("C", numberFormat);
            //    notification.OrderTotalExcludeTax = (value.ModifiedOrder.Sum - value.ModifiedOrder.Tax).ToString("C", numberFormat);
            //    notification.TaxTotal = value.ModifiedOrder.Tax.ToString("C", numberFormat);

            //    notifications.Add(notification);
            //}

            //if (IsNewStatus(value))
            //{
            //    var notification = _notificationManager.GetNewNotification<NewOrderStatusEmailNotification>(value.ModifiedOrder.StoreId, "Store", store.DefaultLanguage);
            //    notification.OrderNumber = value.ModifiedOrder.Number;
            //    notification.NewStatus = value.ModifiedOrder.Status;
            //    notification.OldStatus = value.OrigOrder.Status;

            //    notifications.Add(notification);
            //}

            //if (IsOrderPaid(value))
            //{
            //    var notification = _notificationManager.GetNewNotification<OrderPaidEmailNotification>(value.ModifiedOrder.StoreId, "Store", store.DefaultLanguage);
            //    notification.OrderNumber = value.ModifiedOrder.Number;
            //    notification.FullPrice = value.ModifiedOrder.Sum;
            //    notification.PaidDate = DateTime.UtcNow;
            //    notification.Currency = value.ModifiedOrder.Currency.ToString();

            //    notifications.Add(notification);
            //}

            //if (IsOrderSent(value))
            //{
            //    var notification = _notificationManager.GetNewNotification<OrderSentEmailNotification>(value.ModifiedOrder.StoreId, "Store", store.DefaultLanguage);
            //    notification.OrderNumber = value.ModifiedOrder.Number;
            //    notification.SentOrderDate = DateTime.UtcNow;
            //    notification.NumberOfShipments = value.ModifiedOrder.Shipments.Count(i => i.Status == "Send");
            //    notification.ShipmentsNumbers = value.ModifiedOrder.Shipments.Select(i => i.Number).ToArray();

            //    notifications.Add(notification);
            //}

            //foreach (var notification in notifications)
            //{
            //    SetNotificationParameters(notification, store, value);
            //    _notificationManager.ScheduleSendNotification(notification);
            //}
        }

        /// <summary>
        /// Is order was canceled
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsOrderCanceled(OrderChangeEvent value)
        {
            var retVal = false;

            retVal = value.OrigOrder != null &&
                     value.OrigOrder.IsCancelled != value.ModifiedOrder.IsCancelled &&
                     value.ModifiedOrder.IsCancelled;

            return retVal;
        }

        /// <summary>
        /// Is order gets new status
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNewStatus(OrderChangeEvent value)
        {
            var retVal = false;

            retVal = value.OrigOrder != null &&
                     value.OrigOrder.Status != value.ModifiedOrder.Status;

            return retVal;
        }

        /// <summary>
        /// Is order fully paid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsOrderPaid(OrderChangeEvent value)
        {
            var retVal = false;
            foreach (var origPayment in value.OrigOrder.InPayments)
            {
                var modifiedPayment = value.ModifiedOrder.InPayments.FirstOrDefault(i => i.Id == origPayment.Id);
                var paidSum = value.ModifiedOrder.InPayments.Where(i => i.PaymentStatus == PaymentStatus.Paid).Sum(i => i.Sum);
                if (modifiedPayment != null)
                {
                    retVal = modifiedPayment.PaymentStatus == PaymentStatus.Paid && origPayment.PaymentStatus != PaymentStatus.Paid && paidSum == value.ModifiedOrder.Sum;
                }
                if (retVal)
                    break;
            }

            return retVal;
        }

        /// <summary>
        /// Is order fully send
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsOrderSent(OrderChangeEvent value)
        {
            var retVal = false;
            foreach (var origShipment in value.OrigOrder.Shipments)
            {
                var modifiedShipment = value.ModifiedOrder.Shipments.FirstOrDefault(i => i.Id == origShipment.Id);
                if (modifiedShipment != null)
                {
                    retVal = (modifiedShipment.Status != origShipment.Status && modifiedShipment.Status == "Send") || (retVal && modifiedShipment.Status == "Send");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Set base notificaiton parameters (sender, recipient, isActive)
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="value"></param>
        private void SetNotificationParameters(EmailNotification notification, Store store, OrderChangeEvent value)
        {
            notification.Sender = store.Email;
            notification.IsActive = true;

            var isSendingToUserSettingValue = _settingsManager.GetValue(_isSendingToUserSettingName, true);
            var copyRecipientsEmailsSettingValue = _settingsManager.GetArray(_copyEmailsSettingName, new string[] { });

            if (isSendingToUserSettingValue)
            {
                var contact = _contactService.GetById(value.ModifiedOrder.CustomerId);
                if (contact != null)
                {
                    var email = contact.Emails.FirstOrDefault();
                    if (!string.IsNullOrEmpty(email))
                    {
                        notification.Recipient = email;
                    }
                }
                if (string.IsNullOrEmpty(notification.Recipient))
                {
                    if (value.ModifiedOrder.Addresses.Count > 0)
                    {
                        var address = value.ModifiedOrder.Addresses.FirstOrDefault();
                        if (address != null)
                        {
                            notification.Recipient = address.Email;
                        }
                    }
                }
            }

            if(!isSendingToUserSettingValue && copyRecipientsEmailsSettingValue.Any())
            {
                notification.Recipient = copyRecipientsEmailsSettingValue.First();
            }
        }
    }
}