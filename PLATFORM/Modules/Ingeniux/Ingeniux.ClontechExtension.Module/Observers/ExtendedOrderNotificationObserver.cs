using Ingeniux.OracleSoa.Services;
using System;
using System.Diagnostics;
using System.Linq;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Events;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Domain.Store.Model;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Core.Settings;

namespace Ingeniux.ClontechExtension.Module.Observers
{
	public class ExtendedOrderNotificationObserver : IObserver<OrderChangeEvent>
    {
		private IOrderService _orderService;


		public ExtendedOrderNotificationObserver(IOrderService orderService)
        {
			_orderService = orderService;

		}

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

		public void OnNext(OrderChangeEvent value)
		{
			if (IsOrderCanceled(value))
			{
			}
			else if (value.ChangeState == EntryState.Added)
			{
				// •	Orders will be submitted from Virto to Oracle in real time including payment information. 
				// No payment data will be retained in Ingeniux servers including the Virto system. 

				// TODO: Call IOrderService.CreateOrderAsyn
				//_orderService.CreateOrder()

				value.ModifiedOrder.Status = "Processing";

				Trace.TraceInformation("TODO: Call IOrderService.CreateOrderAsync");
			}
			else if (IsOrderPaid(value))
			{
			}
			else if (IsOrderSent(value))
			{
			}
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
    }
}