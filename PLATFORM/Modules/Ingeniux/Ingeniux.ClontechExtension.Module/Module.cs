using Microsoft.Practices.Unity;
using Ingeniux.ClontechExtension.Module.Observers;
using Ingeniux.ClontechExtension.Module.PaymentGateways;
using System;
using System.IO;
using VirtoCommerce.Domain.Order.Events;
using VirtoCommerce.Domain.Payment.Services;
using VirtoCommerce.Platform.Core.ExportImport;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Settings;

namespace Ingeniux.ClontechExtension.Module
{
	public class Module : ModuleBase
    {
        private const string _connectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        #region IModule Members

        public override void SetupDatabase()
        {

        }

        public override void Initialize()
        {
		}

		public override void PostInitialize()
        {
            base.PostInitialize();

            #region Shipment & Payment methods register

            var invoicePaymentMethodFactory = GetInvoicePaymentMethodFunc();
            _container.Resolve<IPaymentMethodsService>().RegisterPaymentMethod(invoicePaymentMethodFactory);
            #endregion

            #region Add dynamic properties

            #endregion

            _container.RegisterType<IObserver<OrderChangeEvent>, ExtendedOrderNotificationObserver>("OrderNotificationObserver");
        }

        public void DoExport(Stream outStream, PlatformExportManifest manifest, Action<ExportImportProgressInfo> progressCallback)
        {
        }

        public void DoImport(Stream inputStream, PlatformExportManifest manifest, Action<ExportImportProgressInfo> progressCallback)
        {
        }

        private Func<PurchaseOrderPaymentMethod> GetInvoicePaymentMethodFunc()
        {
			var settings = _container.Resolve<ISettingsManager>().GetModuleSettings("VirtoCommerce.PurchaseOrder");

			Func<PurchaseOrderPaymentMethod> retVal = () => new PurchaseOrderPaymentMethod("PurchaseOrder")
            {
                Name = "Purchase Order payment gateway",
                Description = "Purchase Order payment gateway integration",
                LogoUrl = "http://icons.iconarchive.com/icons/visualpharm/finance/128/invoice-icon.png",
                Settings = settings,
                IsActive = false
            };

            return retVal;
        }
        #endregion
    }
}
