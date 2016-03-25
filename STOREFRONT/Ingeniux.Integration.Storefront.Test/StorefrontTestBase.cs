using System;
using System.Configuration;
using VirtoCommerce.Client;
using VirtoCommerce.Client.Api;
using VirtoCommerce.Client.Client;

namespace Ingeniux.Integration.Storefront.Test
{
	public class StorefrontTestBase
	{
		protected readonly ICatalogModuleApi CatalogApi;
		protected readonly ICMSContentModuleApi CmsContentApi;
		protected readonly ICommerceCoreModuleApi CommerceCoreApi;
		protected readonly ICustomerManagementModuleApi CustomerManagementApi;
		protected readonly IInventoryModuleApi InventoryApi;
		protected readonly IMarketingModuleApi MarketingApi;
		protected readonly IOrderModuleApi OrderApi;
		protected readonly IPricingModuleApi PricingApi;
		protected readonly IQuoteModuleApi QuoteApi;
		protected readonly ISearchModuleApi SearchApi;
		protected readonly IShoppingCartModuleApi ShoppingCartApi;
		protected readonly IStoreModuleApi StoreApi;
		protected readonly IVirtoCommercePlatformApi VirtoCommercePlatformApi;

		protected string StoreId;

		public StorefrontTestBase()
		{
			var apiClientCfg = new VirtoCommerce.Client.Client.Configuration(GetApiClient());

			CatalogApi = new CatalogModuleApi(apiClientCfg);
			CmsContentApi = new CMSContentModuleApi(apiClientCfg);
			CommerceCoreApi = new CommerceCoreModuleApi(apiClientCfg);
			CustomerManagementApi = new CustomerManagementModuleApi(apiClientCfg);
			InventoryApi = new InventoryModuleApi(apiClientCfg);
			MarketingApi = new MarketingModuleApi(apiClientCfg);
			OrderApi = new OrderModuleApi(apiClientCfg);
			PricingApi = new PricingModuleApi(apiClientCfg);
			QuoteApi = new QuoteModuleApi(apiClientCfg);
			SearchApi = new SearchModuleApi(apiClientCfg);
			ShoppingCartApi = new ShoppingCartModuleApi(apiClientCfg);
			StoreApi = new StoreModuleApi(apiClientCfg);
			VirtoCommercePlatformApi = new VirtoCommercePlatformApi(apiClientCfg);

			StoreId = ConfigurationManager.AppSettings["StoreId"];
		}

		protected ApiClient GetApiClient()
		{
			var baseUrl = ConfigurationManager.ConnectionStrings["VirtoCommerceBaseUrl"].ConnectionString;
			var apiClient = new HmacApiClient(baseUrl, ConfigurationManager.AppSettings["vc-public-ApiAppId"], ConfigurationManager.AppSettings["vc-public-ApiSecretKey"]);
			return apiClient;
		}
	}
}
